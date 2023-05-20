using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace DataService
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection)
        {            
            // Hardcoded because i could not find a workable solution on how to use my Cofiguration to store this in. 
            return serviceCollection.AddDbContext<BIContext>(options => options.UseSqlServer("Server=.;Database=BI_Dev;Trusted_Connection=True"));
        }
    }
}
