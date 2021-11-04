using Newtonsoft.Json;
using NsqSharp;
using NsqSharp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PubSub.Hub
{
    public class Nsq : IDisposable
    {
        private readonly Dictionary<string, Producer> _producers;
        private readonly List<Consumer> _consumers;
        private readonly Config _config;
        private readonly LogLevel _logLevel;
        private readonly string _nsqAddress;
        private readonly string[] _nsqLookupAddresses;
        private Action<string> _globalErrorHandler;
        private static Nsq _default;

        public static Nsq Default => _default ?? (_default = new Nsq());

        public Nsq(string nsqAddress = "127.0.0.1:4150", Config config = null, LogLevel logLevel = LogLevel.Info, params string[] addresses)
        {
            _producers = new Dictionary<string, Producer>();
            _consumers = new List<Consumer>();
            _config = config;
            _logLevel = logLevel;
            _nsqAddress = nsqAddress;
            if (addresses == null || addresses.Length == 0)
                addresses = new[] { "127.0.0.1:4161" };
            _nsqLookupAddresses = addresses;
        }

        public void RegisterGlobalErrorHandler(Action<string> onError)
        {
            _globalErrorHandler = onError;
        }

        public void Publish<T>(T item)
        {
            var topic = typeof(T).FullName;
            var body = JsonConvert.SerializeObject(item);
            _producers[topic].Publish(topic, body);
        }

        public void Subscribe<T>(Action<T> handler, string channel = "default", int threads = 0)
        {
            if (threads <= 0) threads = Environment.ProcessorCount;
            var topic = typeof(T).FullName;

            var producer = new Producer(_nsqAddress, new NilLogger(_logLevel), _config ?? new Config());

            try
            {
                producer.Publish(topic, "#");
            }
            catch (Exception e)
            {
                _globalErrorHandler?.Invoke(e.Message);
            }

            _producers.Add(topic, producer);

            var consumer = new Consumer(topic, channel);
            consumer.AddHandler(new MessageHandler<T>(handler, _globalErrorHandler), threads);
            consumer.ConnectToNsqLookupd(_nsqLookupAddresses);
            _consumers.Add(consumer);
        }

        public void Dispose()
        {
            foreach (var producer in _producers.Values) producer.Stop();
            foreach (var consumer in _consumers) consumer.Stop();
        }

        /// <summary>Message handler</summary>
        public class MessageHandler<T> : IHandler
        {
            private readonly Action<T> _handler;
            private readonly Action<string> _globalErrorHandler;

            public MessageHandler(Action<T> handler, Action<string> onError = null)
            {
                _handler = handler;
                _globalErrorHandler = onError;
            }

            /// <summary>Handles a message.</summary>
            public void HandleMessage(IMessage message)
            {
                try
                {
                    var msg = Encoding.UTF8.GetString(message.Body);
                    if (!msg.StartsWith("{")) return;
                    var model = JsonConvert.DeserializeObject<T>(msg);
                    _handler.Invoke(model);
                }
                catch (Exception e)
                {
                    _globalErrorHandler?.Invoke(e.Message);
                }
            }

            /// <summary>
            /// Called when a message has exceeded the specified maxAttempts.
            /// </summary>
            /// <param name="message">The failed message.</param>
            public void LogFailedMessage(IMessage message)
            {
                _globalErrorHandler?.Invoke($"Nsq[Fail] # {message.Id} has exceeded the specified maxAttempts.");
            }
        }

        /// <summary>Nil logger</summary>
        public class NilLogger : ILogger
        {
            private readonly LogLevel _minLogLevel;

            /// <summary>
            /// Initializes a new instance of the Logger class.
            /// </summary>
            /// <param name="minLogLevel">The minimum <see cref="T:NsqSharp.Core.LogLevel" /> to output.</param>
            public NilLogger(LogLevel minLogLevel)
            {
                _minLogLevel = minLogLevel;
            }

            /// <summary>Writes the output for a logging event.</summary>
            public void Output(LogLevel logLevel, string message)
            {
                //if (logLevel < _minLogLevel) return;
                //message = $"Nsq[{logLevel}] {message}";
            }

            /// <summary>Flushes the output stream.</summary>
            public void Flush()
            {
            }
        }
    }
}
