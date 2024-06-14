using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CineFlex.Domain;
using CineFlex.Persistence;
using CineFlex.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CineFlex.API.Extensions
{
    public static class ServicesRegistrationExtention
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<CineFlexDbContex>();


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            /*         services.AddAuthorization(opt =>
                     {
                         opt.AddPolicy("IsTaskOwner", policy =>
                         {
                             policy.Requirements.Add(new IsTaskOwner());
                         });

                         opt.AddPolicy("IsCheckListOwner", policy =>
                         {
                             policy.Requirements.Add(new IsCheckListOwner());
                         });
                         opt.AddPolicy("IsCheckListTaskOwner", policy =>
                         {
                             policy.Requirements.Add(new IsCheckListTaskOwner());
                         });
                     });

                     services.AddTransient<IAuthorizationHandler, IsTaskOwnerHandler>();
                     services.AddTransient<IAuthorizationHandler, IsCheckListOwnerHandler>();
                     services.AddTransient<IAuthorizationHandler, IsCheckListTaskOwnerHandler>();*/
            services.AddScoped<TokenService>();
            /* services.AddScoped<IUserAccessor, UserAccessor>();*/

            return services;
        }
    }
}
