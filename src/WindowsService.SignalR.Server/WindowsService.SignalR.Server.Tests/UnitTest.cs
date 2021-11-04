using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using WindowsService.SignalR.Server.ServiceInterface;
using WindowsService.SignalR.Server.ServiceModel;

namespace WindowsService.SignalR.Server.Tests
{
    public class UnitTest
    {
        private readonly ServiceStackHost appHost;

        public UnitTest()
        {
            appHost = new BasicAppHost().Init();
            appHost.Container.AddTransient<SendMessageServices>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => appHost.Dispose();

        [Test]
        public void Can_call_MyServices()
        {
            var service = appHost.Container.Resolve<SendMessageServices>();

            var response = (MessageQueryResponse)service.Any(new MessageQuery { q = "" });

            Assert.That(response.list.Count, Is.GreaterThanOrEqualTo(0));
        }
    }
}
