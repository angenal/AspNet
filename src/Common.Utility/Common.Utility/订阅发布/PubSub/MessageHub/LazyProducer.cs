namespace PubSub.MessageHub
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An implementation of the lazy partitioning producer.
    /// </summary>
    internal sealed class LazyProducer : IDisposable
    {
        public static Action<string> StatsHandler;
        private readonly List<Type> _msgTypes = new List<Type>();
        private readonly Dictionary<long, ConcurrentBag<LazyPartitioningModel>> _data = new Dictionary<long, ConcurrentBag<LazyPartitioningModel>>();
        private readonly List<LazyPartitioningModel> _messages = new List<LazyPartitioningModel>();
        private readonly int _onceConcurrentTasks;
        private readonly TimeSpan _lazyTimeSpan;
        private readonly Action<Type, dynamic> _action;
        private readonly Action<Type, dynamic> _actions;
        private readonly bool _isBulk;
        private readonly Thread _thread0;
        private readonly Thread _thread1;
        private readonly bool _isDataTask;
        private bool _started;
        private long _timeStamp;
        private long _timeStampSeed;

        public LazyProducer(TimeSpan lazyTimeSpan, Action<Type, dynamic> action, bool isBulk = false, int onceConcurrentTasks = 0)
        {
            _onceConcurrentTasks = onceConcurrentTasks <= 0 ? Environment.ProcessorCount : onceConcurrentTasks;
            _isDataTask = _onceConcurrentTasks <= Environment.ProcessorCount * 4;
            _lazyTimeSpan = lazyTimeSpan;
            if (isBulk) _actions = action; else _action = action;
            _isBulk = isBulk;
            _timeStamp = _timeStampSeed = DateTimeOffset.Now.ToUnixTimeSeconds();
            _data.Add(_timeStamp, new ConcurrentBag<LazyPartitioningModel>());
            if (_isDataTask) _thread1 = new Thread(RunTimestamp) { IsBackground = true };
            if (_isDataTask) _thread1.Start();
            _thread0 = _isDataTask ? new Thread(RunDataHandle) { IsBackground = true } : new Thread(RunMessagesHandle) { IsBackground = true };
            _thread0.Start();
        }

        public void Publish<T>(Type msgType, T message)
        {
            if (!_started) return;
            if (_isDataTask) _data[_timeStamp].Add(new LazyPartitioningModel(msgType, message));
            else lock (_messages) _messages.Add(new LazyPartitioningModel(msgType, message));
        }

        public void Publishes<T>(Type msgType, T[] messages)
        {
            if (!_started) return;
            if (_isDataTask) foreach (var message in messages) _data[_timeStamp].Add(new LazyPartitioningModel(msgType, message));
            else lock (_messages) _messages.AddRange(messages.Select(message => new LazyPartitioningModel(msgType, message)));
        }

        public void Register(Type msgType)
        {
            lock (_msgTypes) if (!_msgTypes.Contains(msgType)) _msgTypes.Add(msgType);
        }

        public bool IsRegistered(Type msgType)
        {
            lock (_msgTypes) return _msgTypes.Contains(msgType);
        }

        public bool IsBulk()
        {
            return _isBulk;
        }

        private void RunTimestamp()
        {
            while (true)
            {
                lock (_data) _data.Add(_timeStamp + 1, new ConcurrentBag<LazyPartitioningModel>());
                Thread.Sleep(1000);
                Interlocked.Increment(ref _timeStamp);
            }
        }

        private void RunDataHandle()
        {
            _started = true;
            var logTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            var isInterval = _lazyTimeSpan != TimeSpan.Zero && _lazyTimeSpan.TotalMilliseconds > 0;
            while (_started)
            {
                if (isInterval) Thread.Sleep(_lazyTimeSpan); // sleep 1 seconds before parallel tasks, for load reduction

                var msgTypes = _msgTypes.ToArray();
                if (msgTypes.Length == 0) continue;

                var timeStamp = _timeStamp;
                while (_timeStampSeed < timeStamp)
                {
                    if (!_data.ContainsKey(_timeStampSeed)) continue;
                    var items = _data[_timeStampSeed];
                    if (items.TryPeek(out _))
                    {
                        var list = items.ToArray();
                        foreach (var msgType in msgTypes)
                        {
                            var messages = list.Where(t => t.Type == msgType).Select(t => t.Message).ToArray();
                            int n = messages.Length, p = _onceConcurrentTasks;
                            if (n == 0 || p == 0) continue;

                            StatsHandler?.Invoke($"PubSub.MessageHub<{msgType.Name}>.Count: {n} in {logTime.AddSeconds(_timeStampSeed).ToString("h:m:s.fff")}");

                            if (_isBulk)
                            {
                                _actions.Invoke(msgType, messages);
                                continue;
                            }

                            n = n / p + (n % p != 0 ? 1 : 0);
                            for (var i = 0; i < n; i++)
                            {
                                var s = messages.Skip(i * p).Take(p).ToList();
                                Parallel.ForEach(s, message => _action.Invoke(msgType, message));
                            }
                        }
                    }
                    lock (_data) _data.Remove(_timeStampSeed);
                    _timeStampSeed++;
                }
            }
        }

        private void RunMessagesHandle()
        {
            _started = true;
            while (true)
            {
                if (!_started && _messages.Count == 0) return;

                var timestamp = Stopwatch.GetTimestamp();
                Thread.Sleep(_lazyTimeSpan);
                if (!_started) timestamp = Stopwatch.GetTimestamp();
                var now = DateTime.Now;

                var msgTypes = _msgTypes.ToArray();
                if (msgTypes.Length == 0 || _messages.Count == 0) continue;

                LazyPartitioningModel[] models;
                lock (_messages) models = _messages.Where(t => t.Timestamp <= timestamp).ToArray();
                if (models.Length == 0) continue;

                foreach (var msgType in msgTypes)
                {
                    var messages = models.Where(t => t.Type == msgType).Select(t => t.Message).ToArray();
                    if (messages.Length == 0) continue;

                    StatsHandler?.Invoke($"PubSub.MessageHub<{msgType.Name}>.Count: {messages.Length} in {now.Subtract(_lazyTimeSpan).ToString("h:m:s.fff")}");

                    if (_isBulk) _actions.Invoke(msgType, messages);
                    else foreach (var message in messages) _action.Invoke(msgType, message);
                }

                lock (_messages) _messages.RemoveAll(t => t.Timestamp <= timestamp);
            }
        }

        public void Dispose()
        {
            _started = false;
            _thread0?.Join();
        }
    }
}