using System.Text;
using CineFlex.Application.Models;
using CineFlex.Persistence;
using CineFlex.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using CineFlex.Application.Contracts.Persistence;



namespace CineFlex.API;

public static class DependencyInjection
{
    

    public static void AddHttpLogging(this IServiceCollection services)
    {
        services.AddHttpLogging(opt => { opt.LoggingFields = HttpLoggingFields.All; });
    }

    public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
         var jwtSettings = configuration.GetSection("JwtSettings");
    var secretKey = Encoding.UTF8.GetBytes(jwtSettings["SecurityKey"]);
       services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<CineFlexDbContex>();
   services.AddAuthentication(
            opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["JwtSettings:SecurityKey"] ?? ""))
                };
            }
        );
        services.AddAuthorization();


        
       services.AddScoped<IUserRepository, UserRepository>();
       
      
    }
}