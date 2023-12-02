using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain;

namespace UserManagement.EFCore.Common.Configuration
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            ConfigureUserProfileTable(builder);
        }

        private void ConfigureUserProfileTable(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfiles");

            builder.HasKey(x => x.Id);

            builder.Property(m => m.FirstName)
               .HasMaxLength(100);
            builder.Property(m => m.LastName)
                .HasMaxLength(100);
            builder.Property(m => m.PersonalNumber)
              .HasMaxLength(100);
        }
    }
}
