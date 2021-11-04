using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PubSub.Hub
{
    /// <summary>
    /// 高性能-异步延迟-订阅发布
    /// </summary>
    public class Delay : IDisposable
    {
        /// <summary>
        /// Subscribe Tasks
        /// </summary>
        private readonly Dictionary<Type, Action<dynamic>> _action = new Dictionary<Type, Action<dynamic>>();

        /// <summary>
        /// data list
        /// </summary>
        private readonly Dictionary<long, ConcurrentBag<Model>> _data = new Dictionary<long, ConcurrentBag<Model>>();

        /// <summary>
        /// parallel tasks number
        /// </summary>
        private readonly int _onceConcurrentTasks;
        /// <summary>
        /// sleep 1 milliseconds after parallel tasks, for load reduction
        /// </summary>
        private readonly TimeSpan _onceInterval;
        /// <summary>
        /// sleep 1 seconds before parallel tasks, for load reduction
        /// </summary>
        private readonly TimeSpan _interval;
        /// <summary>
        /// a task timeout
        /// </summary>
        private readonly TimeSpan _timeout;
        /// <summary>
        /// a background thread
        /// </summary>
        private readonly Thread _thread0;
        private readonly Thread _thread1;
        private bool _started;
        private long _timeStamp;
        private long _timeStampSeed;

        private static Delay _default;

        public static Delay Default => _default ?? (_default = new Delay(TimeSpan.Zero, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(30)).Start());

        public Delay(TimeSpan onceInterval, TimeSpan interval, TimeSpan timeout, int onceConcurrentTasks = 0)
        {
            _onceConcurrentTasks = onceConcurrentTasks <= 0 ? Environment.ProcessorCount : onceConcurrentTasks;
            _onceInterval = onceInterval;
            _interval = interval;
            _timeout = timeout;
            _timeStamp = _timeStampSeed = DateTimeOffset.Now.ToUnixTimeSeconds();
            _data.Add(_timeStamp, new ConcurrentBag<Model>());
            _thread0 = new Thread(RunSubscribeTasks) { IsBackground = true };
            _thread1 = new Thread(RunPublishTasks) { IsBackground = true };
        }

        /// <summary>
        /// Publish Tasks
        /// </summary>
        /// <param name="item"></param>
        public void Publish<T>(T item)
        {
            if (!_started) return;
            _data[_timeStamp].Add(new Model(typeof(T), item));
        }

        /// <summary>
        /// Subscribe Tasks
        /// </summary>
        /// <param name="handler"></param>
        public void Subscribe<T>(Action<T> handler)
        {
            if (!_started) return;
            _action[typeof(T)] = item => handler(item);
        }

        public void Unsubscribe<T>()
        {
            _action.Remove(typeof(T));
        }

        public void Unsubscribe()
        {
            _action.Clear();
        }

        public Delay Start()
        {
            if (_started) return this;
            try
            {
                _thread0.Start();
                _thread1.Start();
                _started = true;
            }
            catch (Exception)
            {
                // ignored
            }
            return this;
        }

        public void Stop()
        {
            if (!_started) return;
            try
            {
                _started = false;
                _thread1.Abort();
                _thread0.Join();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void Dispose()
        {
            Stop();
            Unsubscribe();
        }

        internal void RunPublishTasks()
        {
            var isInterval = _interval != TimeSpan.Zero && _interval.TotalMilliseconds > 0;
            var millisecondsTimeout = isInterval ? (int)_interval.TotalMilliseconds : 1000;
            while (true)
            {
                lock (_data) _data.Add(_timeStamp + 1, new ConcurrentBag<Model>());
                Thread.Sleep(millisecondsTimeout);
                Interlocked.Increment(ref _timeStamp);
            }
        }

        internal void RunSubscribeTasks()
        {
            var logTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            var isInterval = _interval != TimeSpan.Zero && _interval.TotalMilliseconds > 0;
            var isOnceInterval = _onceInterval != TimeSpan.Zero && _onceInterval.TotalMilliseconds > 0;

            while (_started)
            {
                var types = new Type[_action.Keys.Count];
                _action.Keys.CopyTo(types, 0);
                if (isInterval) Thread.Sleep(_interval); // sleep 1 seconds before parallel tasks, for load reduction
                while (types.Length > 0 && _timeStampSeed < _timeStamp)
                {
                    var items = _data[_timeStampSeed];
                    if (items.TryPeek(out _))
                    {
                        var models = items.ToArray();
                        foreach (var type in types)
                        {
                            var messages = models.Where(t => t.Type == type).ToArray();
                            int index = 0, count = messages.Length;
                            if (count == 0) continue;

                            var logName = $"PubSub.Delay<{type.Name}>";
                            WriteInfoLog($"{logName}.Tasks-Count: {logTime.AddSeconds(_timeStampSeed).ToString("h:m:s.fff")} {count}");

                            while (index < count)
                            {
                                var list = new List<Model>();
                                for (var i = 0; i < _onceConcurrentTasks && index < count; i++, index++)
                                    list.Add(messages[index]);
                                Parallel.ForEach(list, item =>
                                {
                                    try
                                    {
                                        var action = _action[type];
                                        Run(action, item.Message).ConfigureAwait(false).GetAwaiter().GetResult();
                                    }
                                    catch (Exception ex)
                                    {
                                        Publish(item.Message); // rollback after exception
                                        WriteInfoLog($"{logName}.Parallel-Run-Exception: {ex.Message}");
                                    }
                                });
                            }
                            if (isOnceInterval) Thread.Sleep(_onceInterval); // sleep 1 milliseconds after parallel tasks, for load reduction
                        }
                    }
                    lock (_data) _data.Remove(_timeStampSeed);
                    _timeStampSeed++;
                }
            }
        }

        internal Task Run<T>(Action<T> action, T data)
        {
            var task1 = Task.Delay(_timeout);
            var task2 = Task.Factory.StartNew(() => action(data));
            return Task.WhenAny(task1, task2);
        }

        internal void WriteInfoLog(string s)
        {
            log4net.LogManager.GetLogger("Info")?.Info(s);
        }

        /// <summary>
        /// the typed model
        /// </summary>
        internal sealed class Model
        {
            public Type Type { get; set; }
            public dynamic Message { get; set; }
            public Model(Type msgType, dynamic message)
            {
                Type = msgType;
                Message = message;
            }
        }
    }
}
