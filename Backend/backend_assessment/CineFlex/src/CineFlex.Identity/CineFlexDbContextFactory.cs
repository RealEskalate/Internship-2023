using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Identity;
public class CineFlexDbIdentityContextFactory : IDesignTimeDbContextFactory<CineFlexDbIdentityContext>
{
    public CineFlexDbIdentityContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<CineFlexDbIdentityContext>();

        var connectionString = configuration.GetConnectionString("CineFlexConnectionString");

        builder.UseNpgsql(connectionString);

        return new CineFlexDbIdentityContext(builder.Options);
    }
}
