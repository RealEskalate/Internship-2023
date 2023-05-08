using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Domain;
using BlogApp.Domain.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Persistence
{
    public class BlogAppDbContext : DbContext
    {
        public BlogAppDbContext(DbContextOptions<BlogAppDbContext> options)
           : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
  
      
        public DbSet<_Index> _Index { get; set; }
        
        



    }
}
