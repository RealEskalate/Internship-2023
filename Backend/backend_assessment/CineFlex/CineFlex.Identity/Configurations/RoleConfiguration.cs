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
                Id = "51aa4c19-c079-4beb-b223-f3b2b6d3d71c",
                Name = "User",
                NormalizedName = "USER"
            },
    
            new IdentityRole
            {
                Id = "a9b1000b-3331-4e6d-8777-cc1251eb68d6",
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
        );
    }
}