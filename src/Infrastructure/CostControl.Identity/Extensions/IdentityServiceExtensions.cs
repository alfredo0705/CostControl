using CostControl.Application.Contracts.Identity;
using CostControl.Application.Models.Identity;
using CostControl.Identity.Contracts;
using CostControl.Identity.Entities;
using CostControl.Identity.Repositories;
using CostControl.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CostControl.Identity.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                // Configuración de JWT desde appsettings.json
                services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

                // Configuración de DbContext para Identity
                services.AddDbContext<CostControlIdentityDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DBConnectionString"),
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly("CostControl.Identity"); // Especifica el ensamblado de migraciones
                            sqlOptions.EnableRetryOnFailure();
                        }));
                // Configuración de Identity con soporte para roles
                services.AddIdentityCore<AppUser>(opt =>
                {
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequiredLength = 5;
                })
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddRoleValidator<RoleValidator<AppRole>>()
                .AddEntityFrameworkStores<CostControlIdentityDbContext>()
                .AddDefaultTokenProviders();

                // Configuración de autenticación JWT
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"])),
                            ValidateIssuer = true,
                            ValidIssuer = configuration["JwtSettings:Issuer"],
                            ValidateAudience = true,
                            ValidAudience = configuration["JwtSettings:Audience"],
                            ValidateLifetime = true
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnMessageReceived = context =>
                            {
                                var accessToken = context.Request.Query["access_token"];
                                var path = context.HttpContext.Request.Path;
                                return Task.CompletedTask;
                            }
                        };
                    });

                // Inyección de dependencias personalizadas
                services.AddScoped<ITokenService, TokenService>();
                services.AddScoped<IAuthService, AuthService>();
                services.AddScoped<IAplicationUserRepository, AplicationUserRepository>();

                return services;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
