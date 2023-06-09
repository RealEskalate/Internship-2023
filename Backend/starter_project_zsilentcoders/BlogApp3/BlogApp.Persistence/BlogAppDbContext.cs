﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Domain;
using BlogApp.Domain.Common;
using BlogApp.Domain;

namespace BlogApp.Persistence
{
    public class BlogAppDbContext : DbContext
    {
        
        public DbSet<_Index> _Indices { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Review> _Review { get; set; }
        public DbSet<Tag> Tags {get; set;}

         public DbSet<BlogRate> BlogRates { get; set; }

        public DbSet<Comment> Comments { get; set; }
        
        public BlogAppDbContext(DbContextOptions<BlogAppDbContext> options)
           : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            // AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogAppDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<User> Users { get; set; }

    }
}
