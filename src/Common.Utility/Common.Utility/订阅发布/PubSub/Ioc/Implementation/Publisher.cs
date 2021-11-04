namespace PubSub
{
    public class Publisher : IPublisher
    {
        private readonly Hub.Await hub;

        public Publisher(Hub.Await hub)
        {
            this.hub = hub;
        }

        public void Publish<T>(T data) => hub.Publish(data);
    }
}