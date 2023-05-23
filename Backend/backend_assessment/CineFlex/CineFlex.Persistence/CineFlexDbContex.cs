using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Domain.Common;
using CineFlex.Domain;
using CineFlex.Application.Models;
using CineFlex.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;

namespace CineFlex.Persistence
{
    public class CineFlexDbContex:IdentityDbContext<ApplicationUser,IdentityRole,string>
    {
        public CineFlexDbContex(DbContextOptions<CineFlexDbContex> options)
           : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CineFlexDbContex).Assembly);
        
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

        internal Task AddAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        internal object Entry<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public DbSet<CinemaEntity> Cinemas { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Booking> Bookings {get; set;}

    }
}
