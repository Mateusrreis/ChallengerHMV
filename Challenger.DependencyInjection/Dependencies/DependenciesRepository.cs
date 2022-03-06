using Challenger.Models.Models.Interfaces;
using Challenger.Repository.Interfaces;
using Challenger.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Challenger.DependencyInjection
{
    public static class DependenciesRepository
    {
        public static void AddDependencyRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMedicoRepository, MedicoRepository>();
            serviceCollection.AddScoped<IConsultaRepository, ConsultaRepository>();
            serviceCollection.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
        }
    }
}
