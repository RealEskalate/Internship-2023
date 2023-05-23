using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinFlex.Identity
{
    public class CustomIdentityDBContextFactory : IDesignTimeDbContextFactory<CustomIdentityDBContext>
    {
        public CustomIdentityDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "../../CineFlex.API")
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CustomIdentityDBContext>();
            var connectionString = configuration.GetConnectionString("IdentityConnectionString");

            builder.UseNpgsql(connectionString);

            return new CustomIdentityDBContext(builder.Options);
        }
    }
}
