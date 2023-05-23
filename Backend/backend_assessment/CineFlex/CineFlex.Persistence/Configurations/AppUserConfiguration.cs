using CineFlex.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Identity.Configurations
{

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

    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var hasher = new PasswordHasher<AppUser>();
             builder.HasData(
                  new AppUser
                  {
                      Id = "e6c52d57-24b6-4524-be10-eb7bce4d3217",
                      Email = "admin@gmail.com",
                      NormalizedEmail = "ADMIN@GMAIL.COM",
                      UserName = "Admin",
                      NormalizedUserName = "ADMIN",
                      FullName = "Admin User",
                      PasswordHash = hasher.HashPassword(null, "Pa$$w0rdA"),
                      EmailConfirmed = true
                  },
                  new AppUser
                  {
                      Id = "fb8656da-2b94-474f-8709-85e0cd7ea903",
                      Email = "user@gmail.com",
                      NormalizedEmail = "USER@GMAIL.COM",
                      UserName = "User",
                      NormalizedUserName = "USER",
                      FullName = "Just User",
                      PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
                      EmailConfirmed = true
                  }
             );
        }
    }


    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "6123c2b5bf21e81f7ccf9385",
                    UserId = "e6c52d57-24b6-4524-be10-eb7bce4d3217"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "6123c2c9bf21e81f7ccf9386",
                    UserId = "fb8656da-2b94-474f-8709-85e0cd7ea903"
                }
            );
        }
    }
}