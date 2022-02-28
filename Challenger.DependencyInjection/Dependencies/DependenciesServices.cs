using Challenger.Services.Interfaces;
using Challenger.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Challenger.DependencyInjection.Dependencies
{
    public static class DependenciesServices
    {
        public static void AddDependencyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IConsultaServices, ConsultaServices>();
        }
    }
}
