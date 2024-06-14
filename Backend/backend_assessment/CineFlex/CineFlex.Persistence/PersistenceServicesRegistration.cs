using CineFlex.Application.Contracts.Persistence;
using CineFlex.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CineFlex.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CineFlexDbContex>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("CineFlexConnectionString")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICinemaRepository, CinemaRepository>();
            return services;
        }
    }
}
