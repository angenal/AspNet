using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PubSub.Hub
{
    /// <summary>
    /// 高性能-异步-订阅发布 > 3k Requests/sec + The background processing time is about one minute.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Async2<T> : IDisposable
    {
        /// <summary>
        /// Subscribe Tasks
        /// </summary>
        internal List<Delegate> Handlers = new List<Delegate>();

        /// <summary>
        /// data list
        /// </summary>
        private readonly Dictionary<long, ConcurrentBag<T>> _data = new Dictionary<long, ConcurrentBag<T>>();

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

        private static Async2<T> _default;

        public static Async2<T> Default => _default ?? (_default = new Async2<T>(TimeSpan.Zero, TimeSpan.FromSeconds(1), TimeSpan.FromHours(1), -1).Start());

        public Async2(TimeSpan onceInterval, TimeSpan interval, TimeSpan timeout, int onceConcurrentTasks = 0)
        {
            _onceConcurrentTasks = onceConcurrentTasks <= 0 ? Environment.ProcessorCount : onceConcurrentTasks;
            _onceInterval = onceInterval;
            _interval = interval;
            _timeout = timeout;
            _timeStamp = _timeStampSeed = DateTimeOffset.Now.ToUnixTimeSeconds();
            _data.Add(_timeStamp, new ConcurrentBag<T>());
            _thread0 = new Thread(RunSubscribeTasks) { IsBackground = true };
            _thread1 = new Thread(RunPublishTasks) { IsBackground = true };
        }

        /// <summary>
        /// Publish Tasks
        /// </summary>
        /// <param name="item"></param>
        public void Publish(T item)
        {
            if (!_started) return;
            _data[_timeStamp].Add(item);
        }

        /// <summary>
        /// Publish Tasks
        /// </summary>
        /// <param name="items"></param>
        public void Publishes(params T[] items)
        {
            if (!_started) return;
            foreach (var item in items) _data[_timeStamp].Add(item);
        }

        /// <summary>
        /// Subscribe Tasks
        /// </summary>
        /// <param name="handler"></param>
        public void Subscribe(Action<T> handler)
        {
            if (!_started) return;
            Handlers.Add(handler);
        }

        /// <summary>
        /// Subscribe Tasks
        /// </summary>
        /// <param name="handler"></param>
        public void Subscribes(Action<T[]> handler)
        {
            if (!_started) return;
            Handlers.Add(handler);
        }

        /// <summary>
        /// Subscribe Tasks
        /// </summary>
        /// <param name="handler"></param>
        public void Subscribe(Func<T, Task> handler)
        {
            if (!_started) return;
            Handlers.Add(handler);
        }

        /// <summary>
        /// Subscribe Tasks
        /// </summary>
        /// <param name="handler"></param>
        public void Subscribes(Func<T[], Task> handler)
        {
            if (!_started) return;
            Handlers.Add(handler);
        }

        public void Unsubscribe()
        {
            Handlers.Clear();
        }

        public Async2<T> Start()
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
                lock (_data) _data.Add(_timeStamp + 1, new ConcurrentBag<T>());
                Thread.Sleep(millisecondsTimeout);
                Interlocked.Increment(ref _timeStamp);
            }
        }

        internal void RunSubscribeTasks()
        {
            var logName = $"PubSub.Async<{typeof(T).Name}>.";
            var logTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            var isInterval = _interval != TimeSpan.Zero && _interval.TotalMilliseconds > 0;
            var isOnceInterval = _onceInterval != TimeSpan.Zero && _onceInterval.TotalMilliseconds > 0;
            while (_started)
            {
                if (isInterval) Thread.Sleep(_interval); // sleep 1 seconds before parallel tasks, for load reduction
                try
                {
                    while (Handlers.Count > 0 && _timeStampSeed < _timeStamp)
                    {
                        var items = _data[_timeStampSeed];
                        var hasValue = items.TryPeek(out _);
                        if (hasValue) WriteInfoLog($"{logName}.Tasks-Count: {logTime.AddSeconds(_timeStampSeed).ToString("T")} {items.Count}");
                        if (hasValue)
                        {
                            var list = items.ToArray();
                            try
                            {
                                foreach (var handler in Handlers)
                                {
                                    switch (handler)
                                    {
                                        case Action<T[]> action:
                                            Run(action, list).ConfigureAwait(false).GetAwaiter().GetResult();
                                            break;
                                        case Func<T[], Task> func:
                                            Run(func, list).ConfigureAwait(false).GetAwaiter().GetResult();
                                            break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                WriteInfoLog($"{logName}.Parallel-Run-Exception: {ex.Message}");//日志记录
                            }
                            if (isOnceInterval) Thread.Sleep(_onceInterval); // sleep 1 milliseconds after parallel tasks, for load reduction
                        }
                        lock (_data) _data.Remove(_timeStampSeed);
                        _timeStampSeed++;
                    }
                }
                catch (Exception ex)
                {
                    WriteInfoLog($"{logName}.Tasks-Take-Exception: {ex.Message}");//日志记录
                }
            }
        }

        internal Task Run(Action<T> action, T data)
        {
            var task1 = Task.Delay(_timeout);
            var task2 = Task.Factory.StartNew(() => action(data));
            return Task.WhenAny(task1, task2);
        }

        internal Task Run(Func<T, Task> func, T data)
        {
            var task1 = Task.Delay(_timeout);
            var task2 = func(data);
            return Task.WhenAny(task1, task2);
        }

        internal Task Run(Action<T[]> action, T[] data)
        {
            var task1 = Task.Delay(_timeout);
            var task2 = Task.Factory.StartNew(() => action(data));
            return Task.WhenAny(task1, task2);
        }

        internal Task Run(Func<T[], Task> func, T[] data)
        {
            var task1 = Task.Delay(_timeout);
            var task2 = func(data);
            return Task.WhenAny(task1, task2);
        }

        internal void WriteInfoLog(string s)
        {
            log4net.LogManager.GetLogger("Info")?.Info(s);
        }
    }
}
