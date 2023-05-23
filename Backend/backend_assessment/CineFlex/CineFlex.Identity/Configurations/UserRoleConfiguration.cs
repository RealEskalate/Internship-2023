using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineFlex.Identity.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                UserId = "4000b844-74ca-479b-badb-4f41850ae07e",
                RoleId = "51aa4c19-c079-4beb-b223-f3b2b6d3d71c"
            },
            new IdentityUserRole<string>
            {
                UserId = "efa06a55-d0cc-4e01-abbf-870f21d91441",
                RoleId = "a9b1000b-3331-4e6d-8777-cc1251eb68d6"
            }

        );
    }
}