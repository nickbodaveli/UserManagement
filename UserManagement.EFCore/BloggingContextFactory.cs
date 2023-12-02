using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using UserManagement.EFCore.Common;

namespace UserManagement.EFCore
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<UserManagementDbContext>
    {
        public UserManagementDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserManagementDbContext>();
            var connectionString = "server=DESKTOP-KAU7PU8\\SQLEXPRESS;Database=Callap;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True";
            optionsBuilder.UseSqlServer(connectionString);

            return new UserManagementDbContext(optionsBuilder.Options);
        }
    }
}
