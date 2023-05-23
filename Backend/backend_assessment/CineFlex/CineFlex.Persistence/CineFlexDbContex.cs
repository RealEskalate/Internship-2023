using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CineFlex.Domain.Common;
using CineFlex.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });

            //     modelBuilder.Entity<AppUser>()
            //  .HasMany(u => u.Tasks)
            //  .WithOne(t => t.User)
            //  .HasForeignKey(t => t.UserId)
            //  .IsRequired();

            //     modelBuilder.Entity<Domain.Task>()
            //  .HasMany(u => u.CheckLists)
            //  .WithOne(t => t.Tasks)
            //  .HasForeignKey(t => t.TasksId)
            //  .IsRequired();



            // modelBuilder.Entity<System.Threading.Tasks.Task>().HasNoKey();
            // modelBuilder.Entity<CheckList>().HasNoKey();

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

        public DbSet<Seat> Seats { get; set; }
        public DbSet<CinemaEntity> CinemaEntities { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Book> Books { get; set; }




    }
}
