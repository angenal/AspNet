using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace PubSub
{
    public class Hub
    {
        internal List<Handler> Handlers = new List<Handler>();
        private readonly object _locker = new object();

        private static Hub _default;
        public static Hub Default => _default ?? (_default = new Hub());

        public void Publish<T>(T data = default(T))
        {
            foreach (var handler in GetAliveHandlers<T>())
            {
                switch (handler.Action)
                {
                    case Action<T> action:
                        action(data);
                        break;
                    case Func<T, Task> func:
                        func(data).Wait();
                        break;
                }
            }
        }

        public async Task PublishAsync<T>(T data = default(T))
        {
            foreach (var handler in GetAliveHandlers<T>())
            {
                switch (handler.Action)
                {
                    case Action<T> action:
                        action(data);
                        break;
                    case Func<T, Task> func:
                        await func(data);
                        break;
                }
            }
        }

        public void Subscribe<T>(Action<T> handler)
        {
            Subscribe(this, handler);
        }

        public void Subscribe<T>(object subscriber, Action<T> handler)
        {
            SubscribeDelegate<T>(subscriber, handler);
        }

        public void Subscribe<T>(Func<T, Task> handler)
        {
            Subscribe(this, handler);
        }

        public void Subscribe<T>(object subscriber, Func<T, Task> handler)
        {
            SubscribeDelegate<T>(subscriber, handler);
        }

        public void Unsubscribe()
        {
            Unsubscribe(this);
        }

        public void Unsubscribe(object subscriber)
        {
            lock (_locker)
            {
                var query = Handlers.Where(a => !a.Sender.IsAlive || a.Sender.Target.Equals(subscriber));

                foreach (var h in query.ToList())
                    Handlers.Remove(h);
            }
        }

        public void Unsubscribe<T>()
        {
            Unsubscribe<T>(this);
        }

        public void Unsubscribe<T>(Action<T> handler)
        {
            Unsubscribe(this, handler);
        }

        public void Unsubscribe<T>(object subscriber, Action<T> handler = null)
        {
            lock (_locker)
            {
                var query = Handlers.Where(a => !a.Sender.IsAlive || a.Sender.Target.Equals(subscriber) && a.Type == typeof(T));

                if (handler != null)
                    query = query.Where(a => a.Action.Equals(handler));

                foreach (var h in query.ToList())
                    Handlers.Remove(h);
            }
        }

        public bool Exists<T>()
        {
            return Exists<T>(this);
        }

        public bool Exists<T>(object subscriber)
        {
            lock (_locker)
            {
                foreach (var h in Handlers)
                {
                    if (Equals(h.Sender.Target, subscriber) && typeof(T) == h.Type)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Exists<T>(object subscriber, Action<T> handler)
        {
            lock (_locker)
            {
                foreach (var h in Handlers)
                {
                    if (Equals(h.Sender.Target, subscriber) &&
                         typeof(T) == h.Type &&
                         h.Action.Equals(handler))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void SubscribeDelegate<T>(object subscriber, Delegate handler)
        {
            var item = new Handler
            {
                Action = handler,
                Sender = new WeakReference(subscriber),
                Type = typeof(T)
            };

            lock (_locker) Handlers.Add(item);
        }

        private List<Handler> GetAliveHandlers<T>()
        {
            PruneHandlers();
            return Handlers.Where(h => h.Type.GetTypeInfo().IsAssignableFrom(typeof(T).GetTypeInfo())).ToList();
        }

        private void PruneHandlers()
        {
            lock (_locker)
            {
                for (var i = Handlers.Count - 1; i >= 0; --i)
                {
                    if (Handlers[i].Sender.IsAlive) continue;
                    Handlers.RemoveAt(i);
                }
            }
        }

        internal class Handler
        {
            public Delegate Action { get; set; }
            public WeakReference Sender { get; set; }
            public Type Type { get; set; }
        }
    }

    public class Hub<T> : IDisposable
    {
        internal List<Delegate> Handlers = new List<Delegate>();

        private readonly ConcurrentDictionary<long, ConcurrentBag<T>> data = new ConcurrentDictionary<long, ConcurrentBag<T>>();
        private readonly int onceConcurrentTasks;
        private readonly TimeSpan interval;
        private readonly TimeSpan timeout;
        private readonly Thread thread;
        private bool started;
        private long timeStamp;
        private long timeStampSeed;
        private static Hub<T> _default;

        public static Hub<T> Default => _default ?? (_default = new Hub<T>(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(30)).Start());

        public Hub(int onceConcurrentTasks = 0) : this(TimeSpan.Zero, TimeSpan.FromSeconds(30), onceConcurrentTasks)
        { }
        public Hub(TimeSpan timeout, int onceConcurrentTasks = 0) : this(TimeSpan.Zero, timeout, onceConcurrentTasks)
        { }
        public Hub(TimeSpan interval, TimeSpan timeout, int onceConcurrentTasks = 0)
        {
            this.onceConcurrentTasks = onceConcurrentTasks <= 0 ? Environment.ProcessorCount : onceConcurrentTasks;
            this.interval = interval;
            this.timeout = timeout;
            thread = new Thread(Run) { IsBackground = true };
            timeStamp = timeStampSeed = DateTimeOffset.Now.ToUnixTimeSeconds();
            data.TryAdd(timeStamp, new ConcurrentBag<T>());
        }

        public void Publish(T item)
        {
            if (!started) return;
            data[timeStamp].Add(item);
        }

        public void Subscribe(Action<T> handler)
        {
            if (!started) return;
            Handlers.Add(handler);
        }

        public void Subscribe(Func<T, Task> handler)
        {
            if (!started) return;
            Handlers.Add(handler);
        }

        public void Unsubscribe()
        {
            Handlers.Clear();
        }

        public Hub<T> Start()
        {
            if (started) return this;
            try
            {
                thread.Start();
                started = true;
            }
            catch (Exception)
            {
                // ignored
            }
            return this;
        }

        public void Stop()
        {
            if (!started) return;
            try
            {
                started = false;
                thread.Join();
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

        private void Run()
        {
            Task.Factory.StartNew(() =>
            {
                do
                {
                    Thread.Sleep(1000);
                    Interlocked.Exchange(ref timeStamp, DateTimeOffset.Now.ToUnixTimeSeconds());
                } while (data.TryAdd(timeStamp, new ConcurrentBag<T>()));
            }, TaskCreationOptions.LongRunning);

            var isInterval = interval != TimeSpan.Zero && interval.TotalMilliseconds > 0;
            while (started)
            {
                if (isInterval) Thread.Sleep(interval);
                try
                {
                    while (timeStampSeed < timeStamp && data.TryRemove(timeStampSeed++, out var items))
                    {
                        while (items.TryPeek(out _))
                        {
                            var list = new List<T>();
                            for (var i = 0; i < onceConcurrentTasks && items.TryTake(out var item); i++)
                                list.Add(item);
                            Parallel.ForEach(list, item =>
                            {
                                foreach (var handler in Handlers)
                                {
                                    switch (handler)
                                    {
                                        case Action<T> action:
                                            Run(action, item).ConfigureAwait(false).GetAwaiter().GetResult();
                                            break;
                                        case Func<T, Task> func:
                                            Run(func, item).ConfigureAwait(false).GetAwaiter().GetResult();
                                            break;
                                    }
                                }
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        private Task Run(Action<T> action, T data = default(T))
        {
            var task1 = Task.Delay(timeout);
            var task2 = Task.Factory.StartNew(() => action(data));
            return Task.WhenAny(task1, task2);
        }

        private Task Run(Func<T, Task> func, T data = default(T))
        {
            var task1 = Task.Delay(timeout);
            var task2 = func(data);
            return Task.WhenAny(task1, task2);
        }
    }
}