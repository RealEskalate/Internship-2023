using CineFlex.Identity.Models;
using CineFlex.Identity.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CineFlex.Identity.Persistence
{
    public class UserIdentityDbContext : IdentityDbContext<AppUser>
    {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(UserIdentityDbContext).Assembly);
        }
    }
}
