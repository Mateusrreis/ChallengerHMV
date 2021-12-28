using ChallengerHMV.Services.AuthenticationService;
using ChallengerHMV.Services.AuthenticationService.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengerHMV.Infra.Ioc.Ioc
{
    public static class DependencyAuthUser
    {
        public static IServiceCollection AddAuthUserServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
