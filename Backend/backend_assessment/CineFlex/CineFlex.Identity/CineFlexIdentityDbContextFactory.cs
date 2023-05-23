using CineFlex.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CineFlex.Persistence
{
    public class CineFlexIdentityDbContextFactory : IDesignTimeDbContextFactory<CineFlexIdentityDbContext>
    {
        public CineFlexIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()+ "/../CineFlex.API")
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CineFlexIdentityDbContext>();
            var connectionString = configuration.GetConnectionString("CineFlexConnectionString");

            builder.UseNpgsql(connectionString);

            return new CineFlexIdentityDbContext(builder.Options);
        }
    }
}
