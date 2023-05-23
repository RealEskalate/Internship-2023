using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineFlex.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "6123c2b5bf21e81f7ccf9385",
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Id = "6123c2c9bf21e81f7ccf9386",
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
        );
    }
}
