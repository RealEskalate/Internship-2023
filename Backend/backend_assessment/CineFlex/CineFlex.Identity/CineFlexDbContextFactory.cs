using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CineFlex.Identity
{
    public class CineFlexDbContextFactory : IDesignTimeDbContextFactory<CineFlexIdentityDbContext>
    {

        public CineFlexIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "/../CineFlex.API")
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CineFlexIdentityDbContext>();
            var connectionString = configurationRoot.GetConnectionString("CineFlexConnectionString");

            builder.UseNpgsql(connectionString);
            return new CineFlexIdentityDbContext(builder.Options);
        }
    }
}

