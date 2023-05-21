using DataService.Extensions;
using DataService.Interfaces;
using DataService.Services;
using DataService.Services.BIServices;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(BackendAPI.Startup))]
namespace BackendAPI
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;

            // == Add universials == 
            services.AddDatabase();
            services.AddLogging();

            // == Services == 
            services.AddTransient<IDataService, DefaultBIService>();
            services.AddTransient<ILoggingService, LoggingService>();

            // == Builds provider ==
            services.BuildServiceProvider();
        }
    }
}
