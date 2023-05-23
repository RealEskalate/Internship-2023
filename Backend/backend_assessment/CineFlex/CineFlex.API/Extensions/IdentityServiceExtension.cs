using System.Text;
using CineFlex.API.Services;
using CineFlex.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using CineFlex.Persistence;
using CineFlex.Infrastructure.Security;

namespace CineFlex.API.Extensions {
    public static class IdentityServerExtensions 
    {

        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<AppUser>(options => 
            {
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<CineFlexDbContex>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opt => {
                        opt.TokenValidationParameters = new TokenValidationParameters{
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = key,
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };   
             });

            services.AddAuthorization(opt => {
                opt.AddPolicy("IsTaskCreator", policy => {
                    policy.Requirements.Add(new IsTaskCreatorRequirement());
                });
            });
            
            services.AddAuthorization(opt => {
                opt.AddPolicy("IsCheckListCreator", policy => {
                    policy.Requirements.Add(new IsCheckListCreatorRequirement());
                });
            });

            services.AddTransient<IAuthorizationHandler, IsTaskCreatorRequirementHandler>();
            services.AddTransient<IAuthorizationHandler, IsCheckListCreatorRequirementHandler>();
            services.AddScoped<TokenService>();
            
            return services;
        }
    }
}
