using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Domain;
using Microsoft.AspNetCore.Identity;

namespace CineFlex.Persistence.Configurations.Entities
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var hasher = new PasswordHasher<AppUser>();

            builder.HasData(
                new AppUser
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
                    Role = AppUser.UserRole.Admin
                }
            );
        }
    }
}
