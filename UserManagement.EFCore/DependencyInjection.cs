using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.EFCore.Common;

namespace UserManagement.EFCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseContext(
        this IServiceCollection services,
        ConfigurationManager configuration)
        {
            services.AddDbContext<UserManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            });

            return services;
        }
    }
}
