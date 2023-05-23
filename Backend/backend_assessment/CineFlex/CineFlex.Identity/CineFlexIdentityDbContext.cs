﻿using CineFlex.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CineFlex.Identity.Configurations;
using System.Collections.Generic;
using System.Text;

namespace CineFlex.Identity
{
    public class CineFlexIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public CineFlexIdentityDbContext(DbContextOptions<CineFlexIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
