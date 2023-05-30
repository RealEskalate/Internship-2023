using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace CineFlex.Identity;

public class CineFlexIdentityDbContextFactory : IDesignTimeDbContextFactory<CineFlexIdentityDbContext>
{
    public CineFlexIdentityDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "../../CineFlex.Api")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<CineFlexIdentityDbContext>();
        var connectionString = configuration.GetConnectionString("CineFlexIdentityConnectionString");

        builder.UseNpgsql(connectionString);

        return new CineFlexIdentityDbContext(builder.Options);
    }
}
