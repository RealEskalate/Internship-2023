using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Domain.Common;
using CineFlex.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CineFlex.Persistence
{
    public class CineFlexDbContex : IdentityDbContext<AppUser>
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

            modelBuilder.Entity<CinemaEntity>()
                .HasOne<AppUser>(c => c.AppUser)
                .WithMany(u => u.Cinemas)
                .HasForeignKey(c => c.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SeatEntity>()
                .HasOne<CinemaEntity>(s => s.Cinema)
                .WithMany(c => c.Seats)
                .HasForeignKey(s => s.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SeatEntity>()
                .HasOne<AppUser>(s => s.AppUser)
                .WithMany(u => u.Seats)
                .HasForeignKey(s => s.AppUserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Booking>()
                .HasOne<AppUser>(b => b.AppUser)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
                .HasOne<Movie>(b => b.Movie)
                .WithMany(m => m.Bookings)
                .HasForeignKey(b => b.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
                .HasOne<CinemaEntity>(b => b.Cinema)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);


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
        public DbSet<CinemaEntity> Cinemas { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<SeatEntity> Seats { get; set; }

        public DbSet<Booking> Bookings { get; set; }



    }
}
