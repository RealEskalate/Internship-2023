using CineFlex.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineFlex.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var hasher = new PasswordHasher<User>();
        builder.HasData(
            new User
            {
                Id = 3,
                Email = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@gmail.COM",
                UserName = "Admin@gmail.com",
                NormalizedUserName = "ADMIN@gmail.COM",
                PasswordHash = hasher.HashPassword(null, "P1"),
                EmailConfirmed = false
            },

            new User
            {
                Id = 4,
                Email = "User@gmail.com",
                NormalizedEmail = "USER@gmail.COM",
                UserName = "User@gmail.com",
                NormalizedUserName = "USER@gmail.COM",
                PasswordHash = hasher.HashPassword(null, "P2"),
                EmailConfirmed = false
            }
        );
    }
}