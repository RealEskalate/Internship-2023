using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BlogApp.Identity
{
    public class BlogAppDbContextFactory : IDesignTimeDbContextFactory<BlogIdentityDbContext>
    {

        public BlogIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "/../BlogApp.API")
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<BlogIdentityDbContext>();
            var connectionString = configurationRoot.GetConnectionString("BlogAppConnectionString");

            builder.UseNpgsql(connectionString);
            return new BlogIdentityDbContext(builder.Options);
        }
    }
}

