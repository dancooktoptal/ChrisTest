using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Services;

namespace ChrisTest.Tests
{
    public class Tests
    {
        public Mock<IWilly> MockWilly = new Mock<IWilly>();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            MockWilly.Setup(x => x.Pee())
                .Returns("Test pee from mock");

            await using var application = new ChrisTestApplication()

                .WithWebHostBuilder(builder => builder
                    .ConfigureServices(services =>
                    {
                        services.AddScoped<IWilly>(sp=>MockWilly.Object);
                    }));


            var client = application.CreateClient();
            var response = await client.GetFromJsonAsync<string>("/pee");

            Assert.AreEqual("Test pee from mock", response);
        }
    }
}