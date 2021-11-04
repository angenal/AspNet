namespace PubSub.MessageHub
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// the lazy partitioning model.
    /// </summary>
    internal sealed class LazyPartitioningModel
    {
        public Type Type { get; set; }
        public dynamic Message { get; set; }
        public long Timestamp { get; set; }

        public LazyPartitioningModel(Type msgType, dynamic message)
        {
            Type = msgType;
            Message = message;
            Timestamp = Stopwatch.GetTimestamp();
        }
    }
}