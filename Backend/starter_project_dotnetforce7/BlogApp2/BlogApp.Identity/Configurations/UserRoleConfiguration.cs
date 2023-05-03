using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BlogApp.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "6123c2b5bf21e81f7ccf9385",
                    UserId = "6123c291bf21e81f7ccf9384"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "6123c2c9bf21e81f7ccf9386",
                    UserId = "6123c26ebf21e81f7ccf9383"
                }
            );
        }
    }
}