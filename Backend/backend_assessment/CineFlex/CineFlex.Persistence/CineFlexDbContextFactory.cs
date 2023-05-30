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
    internal class CineFlexDbContextFactory : IDesignTimeDbContextFactory<CineFlexDbContex>
    {
        public CineFlexDbContex CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "../../CineFlex.Api")
                 .AddJsonFile("appsettings.json")
                 .Build();

            var builder = new DbContextOptionsBuilder<CineFlexDbContex>();
            var connectionString = configuration.GetConnectionString("CineFlexConnectionString");

            builder.UseNpgsql(connectionString);

            return new CineFlexDbContex(builder.Options);
        }
    }
}
