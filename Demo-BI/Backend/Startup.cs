using DataAccess;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace BackendAPI
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;
            services.AddDatabase();
            services.AddLogging();
            services.BuildServiceProvider();
        }
    }
}
