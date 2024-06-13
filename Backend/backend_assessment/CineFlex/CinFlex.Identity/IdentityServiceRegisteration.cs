using CineFlex.Application.Constants.Identity;
using CineFlex.Application.Models.Identity;
using CinFlex.Identity.Models;
using CinFlex.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinFlex.Identity
{
    public static class IdentityServiceRegisteration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services,
                                                                  IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.Configure<ServerSettings>(configuration.GetSection("ServerSettings"));
            services.AddDbContext<CustomIdentityDBContext>(options =>
            options.UseNpgsql( configuration.GetConnectionString("IdentityConnectionString"),
            options => options.MigrationsAssembly(typeof(CustomIdentityDBContext).Assembly.FullName)));

            services.AddIdentity<AuthUser, IdentityRole>()
            .AddEntityFrameworkStores<CustomIdentityDBContext>()
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
}