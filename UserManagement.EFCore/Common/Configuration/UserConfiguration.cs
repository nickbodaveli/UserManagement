using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain;

namespace UserManagement.EFCore.Common.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUserTable(builder);
        }

        private void ConfigureUserTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(m => m.UserName)
               .HasMaxLength(100);
            builder.Property(m => m.Password)
                .HasMaxLength(100);
            builder.Property(m => m.Email)
              .HasMaxLength(100);
            builder.Property(m => m.IsActive);
        }
    }
}
