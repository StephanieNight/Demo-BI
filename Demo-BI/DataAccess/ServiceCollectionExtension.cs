using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddDbContext<BIContext>((provider, options) => options.UseSqlServer("name=ConnectionStrings:SqlDatabase"));
        }
    }
}
