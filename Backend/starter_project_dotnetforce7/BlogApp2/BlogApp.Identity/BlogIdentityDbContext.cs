using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BlogApp.Identity.Models;
using Microsoft.EntityFrameworkCore;
using BlogApp.Identity.Configurations;

namespace BlogApp.Identity;
public class BlogIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public BlogIdentityDbContext(DbContextOptions<BlogIdentityDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
    }
}