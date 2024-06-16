using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineFlex.Persistence.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "6123c2c9bf21e81f7ccf9386",
                UserId = "e6c52d57-24b6-4524-be10-eb7bce4d3217"
            },
            new IdentityUserRole<string>
            {
                RoleId = "6123c2b5bf21e81f7ccf9385",
                UserId = "fb8656da-2b94-474f-8709-85e0cd7ea903"
            }
        );
    }
}