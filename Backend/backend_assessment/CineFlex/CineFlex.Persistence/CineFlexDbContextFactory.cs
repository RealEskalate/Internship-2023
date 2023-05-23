using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CineFlex.Persistence
{
    internal class CineFlexDbContextFactory : IDesignTimeDbContextFactory<CineFlexDbContext>
    {
        public CineFlexDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "/../CineFlex.API")
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CineFlexDbContext>();
            var connectionString = configuration.GetConnectionString("CineFlexConnectionString");

            builder.UseNpgsql(connectionString);

            return new CineFlexDbContext(builder.Options);
        }
    }
}