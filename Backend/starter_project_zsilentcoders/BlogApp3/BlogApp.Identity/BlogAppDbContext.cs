using BlogApp.Identity.Configurations;
using BlogApp.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BlogApp.Identity;

public class BlogAppIdentityDbContext : IdentityDbContext<BlogUser>
{
    public BlogAppIdentityDbContext(DbContextOptions<BlogAppIdentityDbContext> options) :
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