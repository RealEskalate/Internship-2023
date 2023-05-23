using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace CineFlex.Identity;

public class CineFlexIdentityDbContextFactory: IDesignTimeDbContextFactory<CineFlexIdentityDbContext>
{
    public CineFlexIdentityDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configurationRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "../../CineFlex.API")
            .AddJsonFile("appsettings.json")
            .Build();
        var builder = new DbContextOptionsBuilder<CineFlexIdentityDbContext>();
        var connectionString = configurationRoot.GetConnectionString("CineFlexIdentityConnectionString");
        builder.UseNpgsql(connectionString);
        return new CineFlexIdentityDbContext(builder.Options);
    }
}