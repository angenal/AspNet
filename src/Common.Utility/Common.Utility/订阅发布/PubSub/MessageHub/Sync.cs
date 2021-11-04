namespace PubSub.MessageHub
{
    public static class Sync
    {
        private static MessageHub _default;

        /// <summary>
        /// Default Synchronous Message Hub.
        /// </summary>
        public static MessageHub Default => _default ?? (_default = new MessageHub());
    }
}
