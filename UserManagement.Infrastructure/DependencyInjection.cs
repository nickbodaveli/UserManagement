using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManagement.Application.Common.Interfaces;
using UserManagement.Infrastructure.Persistance.Helper;
using UserManagement.Infrastructure.Persistance.Repositories;

namespace UserManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtOptions:SecretKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = System.TimeSpan.Zero,
                };
            });

            services.AddScoped<IUserManagementRepository, UserRepository>();
            services.AddScoped<IUserProfileManagementRepository, UserProfileRepository>();
            services.AddScoped<IHelperRepository, HelperRepository>();
            services.AddScoped<IFakeRepository, FakeRepository>();
            services.AddHttpClient("MyApiClient", client =>
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            });
            return services;
        }
    }
}
