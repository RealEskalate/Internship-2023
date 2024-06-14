using Infrustructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Contracts;

namespace Infrustructure
{
    public static class InfrustructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrustructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IUserAccessor, UserAccessor>();

            return services;
        }
    }
}
