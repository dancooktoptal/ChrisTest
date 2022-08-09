using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace ChrisTest.Tests
{
    class ChrisTestApplication : WebApplicationFactory<Program>
    {

        protected override IHost CreateHost(IHostBuilder builder)
        {
        
            builder.ConfigureServices(services =>
            {
            });

            return base.CreateHost(builder);
        }
    }
}
