using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BlogApp.Persistence
{
    public class BlogAppDbContextFactory : IDesignTimeDbContextFactory<BlogAppDbContext>
    {
        public BlogAppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory() + "../../BlogApp3")
                 .AddJsonFile("appsettings.json")
                 .Build();

            var builder = new DbContextOptionsBuilder<BlogAppDbContext>();
            var connectionString = configuration.GetConnectionString("BlogAppConnectionString");

            builder.UseNpgsql(connectionString);

            return new BlogAppDbContext(builder.Options);
        }
    }
}
