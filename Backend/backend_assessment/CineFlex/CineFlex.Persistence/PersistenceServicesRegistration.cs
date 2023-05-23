using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using CineFlex.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CineFlex.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<CineFlexDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("CineFlexConnectionString")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICinemaRepository, CinemaRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<ISeatRepository, SeatRepository>();
        services.AddScoped<IMovieBookingRepository, MovieBookingRepository>();

        services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<CineFlexDbContext>().AddDefaultTokenProviders();
        return services;
    }
}