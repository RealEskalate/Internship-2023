using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BlogApp.Identity;


public class BlogAppIdentityDbContextFactory : IDesignTimeDbContextFactory<BlogAppIdentityDbContext>
{
    public BlogAppIdentityDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "../../BlogApp.Api")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<BlogAppIdentityDbContext>();
        var connectionString = configuration.GetConnectionString("BlogIdentityConnectionString");

        builder.UseNpgsql(connectionString);

        return new BlogAppIdentityDbContext(builder.Options);
    }
}
