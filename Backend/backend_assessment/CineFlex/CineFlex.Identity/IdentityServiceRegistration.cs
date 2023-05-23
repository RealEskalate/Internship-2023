using App.Application.Models.Identity;
using CineFlex.Application.Contracts.Identity;
using CineFlex.Identity.Models;
using CineFlex.Identity.Persistence;
using CineFlex.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CineFlex.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection ConfigureIdentityService(this IServiceCollection services, IConfiguration configuration)
        {
           services.AddDbContext<UserIdentityDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("CineFlexConnectionString")));

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<UserIdentityDbContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration.GetValue<string>("JwtSettings:Issuer"),
                    ValidAudience = configuration.GetValue<string>("JwtSettings:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetValue<string>("JwtSettings:Key")))
                };
            });

            services.AddScoped<IAuthService, AuthService>();
            return services;

        } 
    }
}
    