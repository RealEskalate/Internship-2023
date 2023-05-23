using System.Text;
using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Models.Identity;
using CineFlex.Identity.Models;
using CineFlex.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CineFlex.Identity;

public static class IdentityServiceRegistration
{
    public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services,
                                                                  IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.Configure<ServerSettings>(configuration.GetSection("ServerSettings"));
        services.AddDbContext<CineFlexIdentityDbContext>(options =>
        options.UseNpgsql(
            configuration.GetConnectionString("CineFlexIdentityConnectionString"
            ),
        options => options.MigrationsAssembly(typeof(CineFlexIdentityDbContext).Assembly.FullName)));

        services.AddIdentity<AppUser, IdentityRole>()
        .AddEntityFrameworkStores<CineFlexIdentityDbContext>()
        .AddDefaultTokenProviders();

        services.AddTransient<IAuthService, AuthService>();
        services.Configure<DataProtectionTokenProviderOptions>(opt =>
                        opt.TokenLifespan = TimeSpan.FromHours(2));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            };
        });
        return services;
    }
}