namespace PubSub.MessageHub
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
#if NET_STANDARD
    using System.Reflection;
#endif

    /// <summary>
    /// An implementation of the <c>Event Aggregator</c> pattern.
    /// </summary>
    public sealed class MessagesHub : IMessagesHub
    {
        private readonly Subscriptions _subscriptions;

        private Action<Type, object> _globalHandler;
        private Action<Guid, Exception> _globalErrorHandler;

        private readonly bool _isLazyProducer;
        private readonly LazyProducer _lazyProducer;

        /// <summary>
        /// Creates an instance of the <see cref="MessageHub"/>.
        /// </summary>
        public MessagesHub() => _subscriptions = new Subscriptions();

        /// <summary>
        /// Creates an instance of the <see cref="MessageHub"/>.
        /// </summary>
        public MessagesHub(TimeSpan lazyTimeSpan)
        {
            _subscriptions = new Subscriptions();
            _isLazyProducer = true;
            _lazyProducer = new LazyProducer(lazyTimeSpan, ProducerActions, true);
        }

        /// <summary>
        /// Registers a callback which is invoked on every message published by the <see cref="MessageHub"/>.
        /// <remarks>Invoking this method with a new <paramref name="onMessage"/>overwrites the previous one.</remarks>
        /// </summary>
        /// <param name="onMessage">
        /// The callback to invoke on every message
        /// <remarks>The callback receives the type of the message and the message as arguments</remarks>
        /// </param>
        public void RegisterGlobalHandler(Action<Type, object> onMessage)
        {
            EnsureNotNull(onMessage);
            _globalHandler = onMessage;
        }

        /// <summary>
        /// Invoked if an error occurs when publishing a message to a subscriber.
        /// <remarks>Invoking this method with a new <paramref name="onError"/>overwrites the previous one.</remarks>
        /// </summary>
        public void RegisterGlobalErrorHandler(Action<Guid, Exception> onError)
        {
            EnsureNotNull(onError);
            _globalErrorHandler = onError;
        }

        /// <summary>
        /// Publishes the <paramref name="message"/> on the <see cref="MessageHub"/>.
        /// </summary>
        /// <typeparam name="T">The type of message to subscribe to</typeparam>
        /// <param name="message">The message to published</param>
        public void Publish<T>(T message)
        {
            var msgType = typeof(T);

            if (_isLazyProducer)
            {
                if (!_lazyProducer.IsRegistered(msgType))
                    return;

                _globalHandler?.Invoke(msgType, message);

                _lazyProducer.Publish(msgType, message);
                return;
            }

            _globalHandler?.Invoke(msgType, message);

            Producer(msgType, message);
        }

        /// <summary>
        /// Publishes many <paramref name="messages"/> on the <see cref="MessageHub"/>.
        /// </summary>
        /// <typeparam name="T">The type of message to subscribe to</typeparam>
        /// <param name="messages"></param>
        public void Publishes<T>(params T[] messages)
        {
            var msgType = typeof(T);

            if (_isLazyProducer)
            {
                if (!_lazyProducer.IsRegistered(msgType))
                    return;

                if (_globalHandler != null)
                    foreach (var message in messages) _globalHandler.Invoke(msgType, message);

                _lazyProducer.Publishes(msgType, messages);
                return;
            }

            if (_globalHandler != null)
                foreach (var message in messages) _globalHandler.Invoke(msgType, message);

            Producers(msgType, messages);
        }

        /// <summary>
        /// The Lazy Producer Actions
        /// </summary>
        /// <param name="msgType">The message type</param>
        /// <param name="messages"></param>
        private void ProducerActions(Type msgType, dynamic messages)
        {
            Producers(msgType, messages);
        }

        /// <summary>
        /// The Producer of Publish
        /// </summary>
        /// <typeparam name="T">The type of message to subscribe to</typeparam>
        /// <param name="msgType"></param>
        /// <param name="message"></param>
        public void Producer<T>(Type msgType, T message)
        {
            var localSubscriptions = _subscriptions.GetTheLatestSubscriptions();

#if NET_STANDARD
            var msgTypeInfo = msgType.GetTypeInfo();
#endif

            // ReSharper disable once ForCanBeConvertedToForeach | Performance Critical
            for (var idx = 0; idx < localSubscriptions.Count; idx++)
            {
                var subscription = localSubscriptions[idx];

#if NET_STANDARD
                if (!subscription.Type.GetTypeInfo().IsAssignableFrom(msgTypeInfo)) { continue; }
#else
                if (!subscription.Type.IsAssignableFrom(msgType)) { continue; }
#endif
                try
                {
                    subscription.Handle(message);
                }
                catch (Exception e)
                {
                    _globalErrorHandler?.Invoke(subscription.Token, e);
                }
            }
        }

        /// <summary>
        /// The Producer of Publish
        /// </summary>
        /// <typeparam name="T">The type of message to subscribe to</typeparam>
        /// <param name="msgType"></param>
        /// <param name="messages"></param>
        public void Producers<T>(Type msgType, T[] messages)
        {
            var localSubscriptions = _subscriptions.GetTheLatestSubscriptions();

#if NET_STANDARD
            var msgTypeInfo = msgType.MakeArrayType().GetTypeInfo();
#endif

            // ReSharper disable once ForCanBeConvertedToForeach | Performance Critical
            for (var idx = 0; idx < localSubscriptions.Count; idx++)
            {
                var subscription = localSubscriptions[idx];

#if NET_STANDARD
                if (!subscription.Type.GetTypeInfo().IsAssignableFrom(msgTypeInfo)) { continue; }
#else
                if (!subscription.Type.IsAssignableFrom(msgType.MakeArrayType())) { continue; }
#endif
                try
                {
                    if (msgType == typeof(T))
                    {
                        subscription.Handle(messages);
                        continue;
                    }

                    dynamic destinationArray = Array.CreateInstance(msgType, messages.Length);
                    Array.Copy(messages, destinationArray, messages.Length);
                    subscription.Handle(destinationArray);
                }
                catch (Exception e)
                {
                    _globalErrorHandler?.Invoke(subscription.Token, e);
                }
            }
        }

        /// <summary>
        /// Subscribes a callback against the <see cref="MessageHub"/> for a specific type of message.
        /// </summary>
        /// <typeparam name="T">The type of message to subscribe to</typeparam>
        /// <param name="action">The callback to be invoked once the message is published on the <see cref="MessageHub"/></param>
        /// <returns>The token representing the subscription</returns>
        public Guid Subscribes<T>(Action<T[]> action) => Subscribes(action, TimeSpan.Zero);

        /// <summary>
        /// Subscribes a callback against the <see cref="MessageHub"/> for a specific type of message.
        /// </summary>
        /// <typeparam name="T">The type of message to subscribe to</typeparam>
        /// <param name="action">The callback to be invoked once the message is published on the <see cref="MessageHub"/></param>
        /// <param name="throttleBy">The <see cref="TimeSpan"/> specifying the rate at which subscription is throttled</param>
        /// <returns>The token representing the subscription</returns>
        public Guid Subscribes<T>(Action<T[]> action, TimeSpan throttleBy)
        {
            EnsureNotNull(action);
            var msgType = typeof(T);
            if (_isLazyProducer) _lazyProducer.Register(msgType);
            return _subscriptions.Register(throttleBy, action);
        }

        /// <summary>
        /// Unsubscribes a subscription from the <see cref="MessageHub"/>.
        /// </summary>
        /// <param name="token">The token representing the subscription</param>
        public void Unsubscribe(Guid token) => _subscriptions.UnRegister(token);

        /// <summary>
        /// Checks if a specific subscription is active on the <see cref="MessageHub"/>.
        /// </summary>
        /// <param name="token">The token representing the subscription</param>
        /// <returns><c>True</c> if the subscription is active otherwise <c>False</c></returns>
        public bool IsSubscribed(Guid token) => _subscriptions.IsRegistered(token);

        /// <summary>
        /// Clears all the subscriptions from the <see cref="MessageHub"/>.
        /// <remarks>The global handler and the global error handler are not affected</remarks>
        /// </summary>
        public void ClearSubscriptions() => _subscriptions.Clear(false);

        /// <summary>
        /// Disposes the <see cref="MessageHub"/>.
        /// </summary>
        public void Dispose()
        {
            _globalHandler = null;
            _globalErrorHandler = null;
            _subscriptions.Clear(true);
            _lazyProducer.Dispose();
        }

        [DebuggerStepThrough]
        private void EnsureNotNull(object obj)
        {
            if (obj is null) { throw new NullReferenceException(nameof(obj)); }
        }
    }
}
