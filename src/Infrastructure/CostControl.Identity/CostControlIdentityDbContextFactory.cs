using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CostControl.Identity
{
    public class CostControlIdentityDbContextFactory : IDesignTimeDbContextFactory<CostControlIdentityDbContext>
    {
        public CostControlIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CostControlIdentityDbContext>();
            var connectionString = configuration.GetConnectionString("DBConnectionString");

            builder.UseSqlServer(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });

            return new CostControlIdentityDbContext(builder.Options);
        }
    }
}
