using CostControl.Application.Contracts.Persistence;
using CostControl.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CostControl.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CostControlDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DBConnectionString"),
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("CostControl.Persistence");
                        sqlOptions.EnableRetryOnFailure();
                    }));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}