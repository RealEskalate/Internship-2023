using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CineFlex.Persistence;

internal class CineFlexDbContextFactory : IDesignTimeDbContextFactory<CineFlexDbContext>
{
    public CineFlexDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "/../CineFlex.API")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<CineFlexDbContext>();
        var connectionString = configuration.GetConnectionString("CineFlexConnectionString");

        builder.UseNpgsql(connectionString);

        return new CineFlexDbContext(builder.Options);
    }
}