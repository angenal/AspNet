namespace PubSub.MessageHub
{
    using System;

    public static class Async
    {
        private static MessagesHub _bulk;
        private static MessageHub _default;
        private static MessageHub _task1;
        private static MessageHub _task2;
        private static MessageHub _task3;

        /// <summary>
        /// Default Log Stats Records.
        /// </summary>
        public static void SetLogStatsHandler(Action<string> handler) => LazyProducer.StatsHandler = handler;

        /// <summary>
        /// Default Asynchronous Bulk Merged Message Hub.
        /// </summary>
        public static MessagesHub Bulk => _bulk ?? (_bulk = new MessagesHub(TimeSpan.FromSeconds(2)));

        /// <summary>
        /// Default Asynchronous Message Hub.
        /// </summary>
        public static MessageHub Default => _default ?? (_default = new MessageHub(TimeSpan.FromSeconds(1)));

        /// <summary>
        /// Task of Asynchronous Message Hub.
        /// </summary>
        public static MessageHub Task1 => _task1 ?? (_task1 = new MessageHub(TimeSpan.FromSeconds(1)));

        /// <summary>
        /// Task of Asynchronous Message Hub.
        /// </summary>
        public static MessageHub Task2 => _task2 ?? (_task2 = new MessageHub(TimeSpan.FromSeconds(1)));

        /// <summary>
        /// Task of Asynchronous Message Hub.
        /// </summary>
        public static MessageHub Task3 => _task3 ?? (_task3 = new MessageHub(TimeSpan.FromSeconds(1)));
    }
}
