using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


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

