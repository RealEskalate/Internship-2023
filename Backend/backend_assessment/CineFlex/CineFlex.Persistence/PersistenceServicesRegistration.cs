using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain.Models;
using CineFlex.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
                
        public static async void ConfigureIdentity(this IServiceCollection services){
            services.AddIdentityCore<AppUser>(o => {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.User.RequireUniqueEmail = true;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<CineFlexDbContex>();

        }

     }
}
