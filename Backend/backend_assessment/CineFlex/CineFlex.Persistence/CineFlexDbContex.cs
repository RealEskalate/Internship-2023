using System.Reflection.Emit;
using System.Reflection;
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
using CineFlex.Domain.Models;

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
            modelBuilder.Entity<Cinema>()
                .HasMany(cinema => cinema.Seats)
                .WithOne(seat => seat.Cinema)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Seat>()
                .HasOne(seat => seat.Cinema)
                .WithMany(cinema => cinema.Seats)
                .HasForeignKey(seat => seat.CinemaID);

            modelBuilder.Entity<Ticket>()
                .HasOne(ticket => ticket.User)
                .WithMany()
                .HasForeignKey(ticket => ticket.UserID);

            modelBuilder.Entity<Ticket>()
                .HasOne(ticket => ticket.Seat)
                .WithMany()
                .HasForeignKey(ticket => ticket.SeatID);
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
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
