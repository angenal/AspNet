namespace PubSub
{
    public class PubSubPipelineFactory : IPubSubPipelineFactory
    {
        private readonly Hub.Await hub;

        public PubSubPipelineFactory()
        {
            hub = new Hub.Await();
        }

        public IPublisher GetPublisher() => new Publisher(hub);

        public ISubscriber GetSubscriber() => new Subscriber(hub);
    }
}