using CineFlex.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineFlex.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<CineFlexUser>
{
    public void Configure(EntityTypeBuilder<CineFlexUser> builder)
    {
        var hasher = new PasswordHasher<CineFlexUser>();
        builder.HasData(
            new CineFlexUser
            {
                Id = "4000b844-74ca-479b-badb-4f41850ae07e",
                Email = "Admin@TMS.com",
                FullName = "debebe",
                NormalizedEmail = "ADMIN@HR.COM",
                UserName = "Admin@TMS.com",
                NormalizedUserName = "ADMIN@HR.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = false
            },

            new CineFlexUser
            {
                Id = "efa06a55-d0cc-4e01-abbf-870f21d91441",
                Email = "User@TMS.com",
                FullName = "shelete",
                NormalizedEmail = "USER@HR.COM",
                UserName = "User@TMS.com",
                NormalizedUserName = "USER@HR.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword2"),
                EmailConfirmed = false
            }
        );
    }
}