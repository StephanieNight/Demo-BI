using DataService.Extensions;
using DataService.Interfaces;
using DataService.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

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

            // == Builds provider ==
            services.BuildServiceProvider();
        }
    }
}
