using CineFlex.Domain;
using CineFlex.Domain.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CineFlex.Persistence;

public class CineFlexDbContext : IdentityDbContext<AppUser>
{
    public CineFlexDbContext(DbContextOptions<CineFlexDbContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    public DbSet<CinemaEntity> Cinemas { get; set; }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<MovieBooking> MovieBookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CineFlexDbContext).Assembly);

        // Cinema
        modelBuilder.Entity<CinemaEntity>()
            .HasMany(e => e.Seats)
            .WithOne(e => e.Cinema)
            .HasForeignKey(e => e.CinemaId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        // Seats
        modelBuilder.Entity<Seat>().HasKey(e => e.Id);
        
        // Movies
        modelBuilder.Entity<Movie>().HasKey(e => e.Id);
        modelBuilder.Entity<Movie>()
            .HasMany(e => e.MovieBookings)
            .WithOne(e => e.Movie)
            .HasForeignKey(e => e.MovieId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        // MovieBookings
        modelBuilder.Entity<MovieBooking>().HasKey(e => e.Id);
        modelBuilder.Entity<MovieBooking>()
            .HasOne(e => e.Movie)
            .WithMany()
            .HasForeignKey(e => e.MovieId)
            .IsRequired();
        modelBuilder.Entity<MovieBooking>()
            .HasOne(e => e.Cinema)
            .WithMany()
            .HasForeignKey(e => e.CinemaId)
            .IsRequired();
        modelBuilder.Entity<MovieBooking>()
            .HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .IsRequired();
        modelBuilder.Entity<MovieBooking>()
            .HasMany(e => e.Seats)
            .WithMany(e => e.MovieBookings);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
        {
            entry.Entity.LastModifiedDate = DateTime.Now;

            if (entry.State == EntityState.Added) entry.Entity.DateCreated = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}