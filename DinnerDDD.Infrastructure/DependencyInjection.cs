using DinnerDDD.Application.Common.Interfaces.Authentication;
using DinnerDDD.Application.Common.Interfaces.Persistence;
using DinnerDDD.Application.Common.Interfaces.Services;
using DinnerDDD.Infrastructure.Authentication;
using DinnerDDD.Infrastructure.Persistence;
using DinnerDDD.Infrastructure.Persistence.Repositories;
using DinnerDDD.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DinnerDDD.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddAuth(configuration)
                    .AddPersistance();

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }

        public static IServiceCollection AddPersistance(
           this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            return services;
        }

        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            var JwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, JwtSettings);

            services.AddDbContext<DinnerDDDContext>(options => 
                                                    options.UseSqlServer("Server=localhost;Database=DinnerDDD;User Id=sa;Password=1234567890;TrustServerCertificate=true"));

            services.AddSingleton(Options.Create(JwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(ops => ops.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = JwtSettings.Issuer,
                        ValidAudience = JwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Secret)),

                    });

            return services;
        }

    }

}
