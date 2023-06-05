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
    public class CineFlexAppDbContextFactory : IDesignTimeDbContextFactory<CineFlexIdentityDbContext>
    {

        public CineFlexIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "/../CineFlexApp.API")
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CineFlexIdentityDbContext>();
            var connectionString = configurationRoot.GetConnectionString("CineFlexAppConnectionString");

            builder.UseNpgsql(connectionString);
            return new CineFlexIdentityDbContext(builder.Options);
        }
    }
}
