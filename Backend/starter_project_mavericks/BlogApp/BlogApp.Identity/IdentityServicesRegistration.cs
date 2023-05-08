using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Models.Identity;
using BlogApp.Domain;
using BlogApp.Identity.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlogApp.Persistence
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserIdentityDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("BlogAppConnectionString")));

            
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<UserIdentityDbContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {};
            });

            services.AddScoped<IAuthRepository, AuthRepository>();
            return services;
        }
    }
}
