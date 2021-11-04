using Funq;
using ServiceStack;
using NUnit.Framework;
using WindowsService.SignalR.Server.ServiceInterface;
using WindowsService.SignalR.Server.ServiceModel;

namespace WindowsService.SignalR.Server.Tests
{
    public class IntegrationTest
    {
        const string BaseUri = "http://localhost:2000/";
        private readonly ServiceStackHost appHost;

        class AppHost : AppSelfHostBase
        {
            public AppHost() : base(nameof(IntegrationTest), typeof(SendMessageServices).Assembly) { }

            public override void Configure(Container container)
            {
            }
        }

        public IntegrationTest()
        {
            appHost = new AppHost()
                .Init()
                .Start(BaseUri);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => appHost.Dispose();

        public IServiceClient CreateClient() => new JsonServiceClient(BaseUri);

        [Test]
        public void Can_call_Hello_Service()
        {
            var client = CreateClient();

            var response = client.Get(new MessageQuery { q = "" });

            Assert.That(response.list.Count, Is.GreaterThanOrEqualTo(0));
        }
    }
}