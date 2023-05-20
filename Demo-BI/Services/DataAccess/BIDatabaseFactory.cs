using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess
{
    public class BIDatabaseFactory : IDesignTimeDbContextFactory<BIContext>
    {

        public BIContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BIContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=BI_Dev;Trusted_Connection=True");

            return new BIContext(
                optionsBuilder.Options);
        }
    }
}
