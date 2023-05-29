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

namespace CineFlex.Persistence
{
    public class CineFlexDbContex: DbContext
    {
        public CineFlexDbContex(DbContextOptions<CineFlexDbContex> options)
           : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CineFlexDbContex).Assembly);
            modelBuilder.Entity<MovieBooking>()
                .HasOne(mb => mb.Movie)
                .WithMany(m => m.MovieBookings)
                .HasForeignKey(mb => mb.MovieId);

            modelBuilder.Entity<MovieBooking>()
                .HasOne(mb => mb.CinemaEntity)
                .WithMany()
                .HasForeignKey(mb => mb.CinemaId);

            modelBuilder.Entity<MovieBooking>()
                .HasMany(mb => mb.Seats)
                .WithOne(s => s.MovieBooking)
                .HasForeignKey(s => s.MovieBookingId);
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
        public DbSet<Seat> Seats { get; set; }


    }
}
