using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using CineFlex.Domain.Common;
using CineFlex.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CineFlex.Persistence
{
    public class CineFlexDbContex: IdentityDbContext<AppUser>
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
/*
            modelBuilder.Entity<Seat>()
                    .HasKey(seat => new { seat.SeatNo, seat.Cinema.Id});*/

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.Ignore(u => u.PhoneNumber);
                entity.Ignore(u => u.PhoneNumberConfirmed);
                entity.Ignore(u => u.TwoFactorEnabled);
                entity.Ignore(u => u.LockoutEnabled);
                entity.Ignore(u => u.LockoutEnd);
            });
            base.OnModelCreating(modelBuilder);
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

        public DbSet<Booking> Bookings { get; set; }
    }
}
