using CineFlex.Identity.Configurations;
using CineFlex.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CineFlex.Identity;

public class CineFlexIdentityDbContext : IdentityDbContext<CineFlexUser>
{
    public CineFlexIdentityDbContext(DbContextOptions<CineFlexIdentityDbContext> options) :
        base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new UserRoleConfiguration());
    }
}