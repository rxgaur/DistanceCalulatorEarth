
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using WebApp;

namespace DistanceCalculator.IntegrationTests
{
    public class TestClientProvider
    {
        public HttpClient Client { get; }

        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseEnvironment("Testing").UseStartup<Startup>());
            Client = server.CreateClient();
        }
    }
}
