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
            // Relationship between CinemaEntity and Seat
            modelBuilder.Entity<CinemaEntity>()
                .HasMany(c => c.Seats)
                .WithOne(s => s.Cinema)
                .HasForeignKey(s => s.CinemaHallId);

            // Relationship between Movie and Genre
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies)
                .UsingEntity(j => j.ToTable("MovieGenres"));

            // Relationship between Movie and Booking
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Bookings)
                .WithOne(b => b.Movie)
                .HasForeignKey(b => b.MovieId);

            // Relationship between Booking and Seat
            modelBuilder.Entity<Booking>()
                .HasMany(b => b.Seats)
                .WithOne(s => s.Booking)
                .HasForeignKey(s => s.BookingId);


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
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}
