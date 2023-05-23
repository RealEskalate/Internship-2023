using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Identity.Models;

namespace CineFlex.Identity.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration< AppUser>
    {
        public void Configure(EntityTypeBuilder< AppUser> builder)
        {
            var hasher = new PasswordHasher< AppUser>();
            builder.HasData(
                 new  AppUser
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     Email = "admin@localhost.com",
                     NormalizedEmail = "ADMIN@LOCALHOST.COM",
                     UserName = "admin@localhost.com",
                     NormalizedUserName = "ADMIN@LOCALHOST.COM",
                     FullName = "System Admin",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                     EmailConfirmed = true
                 },
                 new  AppUser
                 {
                     Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                     Email = "user@localhost.com",
                     NormalizedEmail = "USER@LOCALHOST.COM",
                     FullName = "System User",
                     UserName = "user@localhost.com",
                     NormalizedUserName = "USER@LOCALHOST.COM",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                     EmailConfirmed = true
                 }
            );
        }
    }
}