using NATS.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PubSub.Hub
{
    /// <summary>
    /// Nats Client
    /// </summary>
    public partial class Nats
    {
        internal static List<dynamic> instances = new List<dynamic>();
        private static readonly object locker = new object();

        private static Options _options;
        public static Options DefaultOptions(string token = "HGJ766GR767FKJU0", string url = "nats://localhost:4222")
        {
            if (_options != null) return _options;
            _options = ConnectionFactory.GetDefaultOptions();
            _options.Url = url;
            _options.Token = token;
            _options.AllowReconnect = true; // auto reconnect.
            _options.MaxReconnect = 1200; // Options.ReconnectForever
            _options.ReconnectWait = 2000; // 2 second
            _options.PingInterval = 60000; // 1 minute
            _options.Timeout = 2000; // 2 second
            _options.ReconnectBufferSize = 104857600; // 100Mb size of messages kept while busy reconnecting.
            _options.SubChannelLength = 100000000; // sets number of messages the subscriber will buffer internally.
            return _options;
        }

        /// <summary>
        /// Shared Nats Client
        /// </summary>
        /// <typeparam name="T">Message Type</typeparam>
        public static Nats<T> Default<T>(string aSubject = null, Options aOptions = null) => Nats<T>.Default(aSubject, aOptions);

        /// <summary>
        /// Gets Registered Nats Client
        /// </summary>
        /// <typeparam name="T">Message Type</typeparam>
        public static Nats<T> Get<T>() => instances.Find(c => c is Nats<T>);

        /// <summary>
        /// Register Nats Client
        /// </summary>
        /// <typeparam name="T">Message Type</typeparam>
        public static Nats<T> Register<T>(string aSubject = null, string bSubject = null, Action<T> handler = null)
        {
            lock (locker)
            {
                Nats<T> instance = instances.Find(c => c is Nats<T>);
                if (instance == null)
                {
                    instance = Nats<T>.New(aSubject, DefaultOptions());
                    if (handler != null) instance.CreateSubscribe(handler, bSubject);
                    instances.Add(instance);
                }
                return instance;
            }
        }

        /// <summary>
        /// Registers Nats Client
        /// </summary>
        /// <typeparam name="T">Message Type</typeparam>
        public static Nats<T> Registers<T>(string aSubject = null, string bSubject = null, Action<T[]> handler = null)
        {
            lock (locker)
            {
                Nats<T> instance = instances.Find(c => c is Nats<T>);
                if (instance == null)
                {
                    instance = Nats<T>.New(aSubject, DefaultOptions());
                    if (handler != null) instance.CreateSubscribes(handler, bSubject);
                    instances.Add(instance);
                }
                return instance;
            }
        }
    }

    /// <summary>
    /// Nats Client
    /// </summary>
    /// <typeparam name="T">Message Type</typeparam>
    public class Nats<T> : IDisposable
    {
        public JsonConverter[] JsonConverters = new JsonConverter[] { new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" } };

        #region private properties

        internal List<Delegate> Handlers = new List<Delegate>();
        private static Nats<T> _default;
        private readonly Dictionary<long, List<T>> _data = new Dictionary<long, List<T>>();
        private readonly long _bytesLimit;
        private readonly Options _aOptions;
        private readonly ConnectionFactory _cf;
        private long _pubConnectionSeed;
        private List<IConnection> _pub;
        private IConnection _sub;
        private readonly int _cpuCount = Environment.ProcessorCount;
        private readonly int _onceConcurrentTasks;
        private readonly int _onceMaxTasks;
        private readonly TimeSpan _interval;
        private readonly TimeSpan _timeout;
        private readonly Thread _thread;
        private readonly object _locker = new object();
        private bool _disposed;
        private bool _started;

        #endregion

        /// <summary>
        /// Current Subject
        /// </summary>
        public string Subject { get; }

        /// <summary>
        /// Shared Nats Client
        /// </summary>
        public static Nats<T> Default(string aSubject = null, Options aOptions = null) => _default ?? (_default = New(aSubject, aOptions));

        /// <summary>
        /// New Nats Client
        /// </summary>
        public static Nats<T> New(string aSubject = null, Options aOptions = null) => new Nats<T>(aSubject, aOptions, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(1)).Start();

        /// <summary>
        /// New Nats Client
        /// </summary>
        public static Nats<T1> New<T1>(string aSubject = null, Options aOptions = null) => new Nats<T1>(aSubject, aOptions, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(1)).Start();

        /// <summary>
        /// New Nats Client
        /// </summary>
        /// <param name="aSubject"></param>
        /// <param name="aOptions"></param>
        /// <param name="interval"></param>
        /// <param name="timeout"></param>
        /// <param name="onceConcurrentTasks">Default ProcessorCount</param>
        /// <param name="onceMaxTasks">Default ProcessorCount * 100</param>
        /// <param name="bytesLimitOfAMessage">Default 10MB Limit A Message Bytes</param>
        public Nats(string aSubject, Options aOptions, TimeSpan interval, TimeSpan timeout, int onceConcurrentTasks = 0, int onceMaxTasks = 0, int bytesLimitOfAMessage = 10485760)
        {
            Subject = string.IsNullOrEmpty(aSubject) ? typeof(T).Name : aSubject;
            _aOptions = aOptions ?? Nats.DefaultOptions();
            _cf = new ConnectionFactory();
            _bytesLimit = _aOptions.SubChannelLength * bytesLimitOfAMessage;
            _onceConcurrentTasks = onceConcurrentTasks <= 0 ? _cpuCount : onceConcurrentTasks;
            _onceMaxTasks = onceMaxTasks <= 0 ? _onceConcurrentTasks * 100 : onceMaxTasks;
            _interval = interval < TimeSpan.FromSeconds(1) ? TimeSpan.FromSeconds(1) : interval;
            _timeout = timeout < TimeSpan.FromSeconds(2) ? TimeSpan.FromSeconds(2) : timeout;
            _thread = new Thread(Run) { IsBackground = true };
            //aOptions.DisconnectedEventHandler = (sender, e) =>
            //{
            //    if (!_started) return;
            //    if (e.Conn.ConnectedId.Equals(_sub.ConnectedId) && e.Conn.IsClosed()) CreateSubscribeConnection();
            //    foreach (var s in _pub) if (e.Conn.ConnectedId.Equals(s.ConnectedId) && e.Conn.IsClosed()) CreatePublishConnection(s.ConnectedId);
            //};
        }

        /// <summary>
        /// Publish a message
        /// </summary>
        /// <param name="item"></param>
        /// <param name="flush"></param>
        public void Publish(T item, bool flush = false)
        {
            if (!_started) return;
            var p = Serialize(item);
            var c = Interlocked.Increment(ref _pubConnectionSeed);
            var i = (int)(c % _cpuCount);
            var s = _pub[i]; s.Publish(Subject, p);
            if (flush || 0 == (c + 1) % 8192) s.Flush();
        }

        /// <summary>
        /// Publish a group messages
        /// </summary>
        /// <param name="items"></param>
        public void Publishes(params T[] items)
        {
            if (!_started) return;
            foreach (var item in items)
            {
                var p = Serialize(item);
                var c = Interlocked.Increment(ref _pubConnectionSeed);
                var i = (int)(c % _cpuCount);
                var s = _pub[i]; s.Publish(Subject, p);
                if (0 == (c + 1) % 8192) s.Flush();
            }
        }

        /// <summary>
        /// Subscribe a message handler
        /// </summary>
        /// <param name="handler"></param>
        public void Subscribe(Action<T> handler)
        {
            if (!_started) return;
            Handlers.Add(handler);
        }

        /// <summary>
        /// Subscribe a group messages handler
        /// </summary>
        /// <param name="handler"></param>
        public void Subscribes(Action<T[]> handler)
        {
            if (!_started) return;
            Handlers.Add(handler);
        }

        /// <summary>
        /// Unsubscribe all handlers
        /// </summary>
        public void Unsubscribe()
        {
            Handlers.Clear();
        }

        /// <summary>
        /// Create Publish Connection, default formatter serializing objects using the BinaryFormatter
        /// </summary>
        protected void CreatePublishConnection(string connectedId = null)
        {
            lock (_locker)
            {
                if (connectedId != null && _pub.Any())
                {
                    for (var i = 0; i < _cpuCount; i++)
                        if (_pub[i].ConnectedId == connectedId) _pub[i] = _cf.CreateConnection(_aOptions);
                    return;
                }
                _pub = new List<IConnection>();
                for (var i = 0; i < _cpuCount; i++) _pub.Add(_cf.CreateConnection(_aOptions));
            }
        }

        /// <summary>
        /// Create Subscribe a messages handler
        /// </summary>
        /// <param name="handler"></param>
        public void CreateSubscribe(Action<T> handler, string bSubject = null)
        {
            lock (_locker)
            {
                _sub = _cf.CreateConnection(_aOptions);
                var s = _sub.SubscribeAsync(string.IsNullOrEmpty(bSubject) ? Subject : bSubject, (sender, e) =>
                {
                    if (e.Message?.Data == null) return;
                    var item = Deserialize(e.Message.Data);
                    if (item == null) return;
                    Run(handler, item).ConfigureAwait(false).GetAwaiter().GetResult();
                });
                s.SetPendingLimits(_aOptions.SubChannelLength, _bytesLimit);
                _sub.Flush();
            }
        }

        /// <summary>
        /// Create Subscribe a group messages handler
        /// </summary>
        /// <param name="handler"></param>
        public void CreateSubscribes(Action<T[]> handler, string bSubject = null)
        {
            lock (_locker)
            {
                _sub = _cf.CreateConnection(_aOptions);
                var s = _sub.SubscribeAsync(string.IsNullOrEmpty(bSubject) ? Subject : bSubject, (sender, e) =>
                {
                    if (e.Message?.Data == null) return;
                    var items = Deserializes(e.Message.Data);
                    if (items == null || items.Length == 0) return;
                    Run(handler, items).ConfigureAwait(false).GetAwaiter().GetResult();
                });
                s.SetPendingLimits(_aOptions.SubChannelLength, _bytesLimit);
                _sub.Flush();
            }
        }

        /// <summary>
        /// Create Subscribe Connection, default formatter serializing objects using the BinaryFormatter
        /// </summary>
        protected void CreateSubscribeConnection()
        {
            lock (_locker)
            {
                _sub = _cf.CreateConnection(_aOptions);
                var s = _sub.SubscribeAsync(Subject, (sender, e) =>
                {
                    if (e.Message?.Data == null) return;
                    var item = Deserialize(e.Message.Data);
                    if (item == null) return;
                    var ts = DateTimeOffset.Now.ToUnixTimeSeconds();
                    if (_data.ContainsKey(ts)) _data[ts].Add(item);
                    else _data.Add(ts, new List<T> { item });
                });
                s.SetPendingLimits(_aOptions.SubChannelLength, _bytesLimit);
                _sub.Flush();
            }
        }

        /// <summary>
        /// Start Connect
        /// </summary>
        /// <param name="onlyPublish"></param>
        /// <returns></returns>
        public Nats<T> Start(bool onlyPublish = false)
        {
            if (_started) return this;
            CreatePublishConnection();
            if (!onlyPublish) CreateSubscribeConnection();
            try
            {
                _thread.Start();
                _started = true;
            }
            catch (Exception)
            {
                // ignored
            }
            return this;
        }

        /// <summary>
        /// Stop Connect
        /// </summary>
        public void Stop()
        {
            if (!_started) return;
            try
            {
                _started = false;
                _thread.Join();
                foreach (var s in _pub) s.Close();
                _sub.Drain();
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
            _disposed = true;
        }

        private void Run()
        {
            var maxNum = _onceMaxTasks / _onceConcurrentTasks; // default 100
            var ts1 = DateTimeOffset.Now.ToUnixTimeSeconds();
            while (_started)
            {
                if (_disposed) return;
                Thread.Sleep(_interval);
                if (Handlers.Count == 0) continue;

                var ts2 = DateTimeOffset.Now.ToUnixTimeSeconds() - _interval.TotalSeconds;
                var isBulk = Handlers.Any(a => a is Action<T[]>);

                try
                {
                    while (ts1 < ts2)
                    {
                        if (!_data.ContainsKey(ts1)) { ts1++; continue; }
                        if (ts1 >= ts2) break;

                        var data = _data[ts1];
                        var count = data.Count;
                        if (count == 0) { _data.Remove(ts1); ts1++; continue; }
                        int index = 0, page = isBulk ? maxNum : _onceConcurrentTasks;

                        while (index < count)
                        {
                            try
                            {
                                var list = data.Skip(index).Take(page).ToList();
                                RunParallel(list, isBulk);
                                index += list.Count;
                            }
                            catch
                            {
                                break;
                            }
                        }

                        if (index == 0) break;
                        if (index == count) { _data.Remove(ts1); ts1++; continue; }
                        _data[ts1].RemoveRange(0, index); break;
                    }
                }
                catch (Exception)
                {
                    //_sub.ResetStats();
                }
                finally
                {
                    if (DateTime.Now.Hour == 3 && _data.Count == 0 && Interlocked.Read(ref _pubConnectionSeed) > 0)
                    {
                        Interlocked.Exchange(ref _pubConnectionSeed, 0);
                        foreach (var s in _pub) s.Flush();
                        _sub.Flush();
                    }
                }
            }
        }

        private void RunParallel(List<T> list, bool isBulk)
        {
            if (list.Count == 0) return;

            if (isBulk)
            {
                foreach (var handler in Handlers)
                {
                    if (handler is Action<T[]> action)
                    {
                        Run(action, list.ToArray()).ConfigureAwait(false).GetAwaiter().GetResult();
                    }
                }
                return;
            }

            Parallel.ForEach(list, item =>
            {
                foreach (var handler in Handlers)
                {
                    if (handler is Action<T> action)
                    {
                        Run(action, item).ConfigureAwait(false).GetAwaiter().GetResult();
                    }
                }
            });
        }

        private Task Run(Action<T> action, T data = default(T))
        {
            var task1 = Task.Delay(_timeout);
            var task2 = Task.Factory.StartNew(() => action(data));
            return Task.WhenAny(task1, task2);
        }

        private Task Run(Action<T[]> action, T[] data)
        {
            var task1 = Task.Delay(_timeout);
            var task2 = Task.Factory.StartNew(() => action(data));
            return Task.WhenAny(task1, task2);
        }

        private byte[] Serialize(T o)
        {
            var s = JsonConvert.SerializeObject(o, JsonConverters);
            var p = Encoding.UTF8.GetBytes(s);
            return p;
        }

        private T Deserialize(byte[] p)
        {
            try
            {
                var s = Encoding.UTF8.GetString(p);
                var o = JsonConvert.DeserializeObject<T>(s);
                return o;
            }
            catch
            {
                return default(T);
            }
        }

        private T[] Deserializes(byte[] p)
        {
            try
            {
                var s = Encoding.UTF8.GetString(p);
                var o = JsonConvert.DeserializeObject<T[]>(s);
                return o;
            }
            catch
            {
                return null;
            }
        }
    }
}