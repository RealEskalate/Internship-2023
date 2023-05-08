using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using BlogApp.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogAppDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("BlogAppConnectionString")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<I_IndexRepository, _IndexRepository>();
            return services;
        }
    }
}
