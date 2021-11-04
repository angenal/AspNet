using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PubSub.Hub
{
    public class Await
    {
        internal List<Handler> Handlers = new List<Handler>();
        private readonly object _locker = new object();

        private static Await _default;
        public static Await Default => _default ?? (_default = new Await());

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
}