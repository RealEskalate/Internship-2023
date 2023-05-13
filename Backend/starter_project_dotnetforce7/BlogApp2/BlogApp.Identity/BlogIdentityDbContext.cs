using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BlogApp.Domain;
using Microsoft.EntityFrameworkCore;
using BlogApp.Identity.Configurations;
using BlogApp.Identity.Models;
using BlogApp.Application.Models.Identity;

namespace BlogApp.Identity;
public class BlogIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<ApplicationUser> Users { get; set; }
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