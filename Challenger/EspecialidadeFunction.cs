using Challenger.DependencyInjection;
using Challenger.DependencyInjection.Dependencies;
using Challenger.Models.Models.Interfaces;
using Challenger.Models.Models.RequestDtos;
using Challenger.Models.Models.ResponseDtos;
using Challenger.Services.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolucionChallenger
{
    public class EspecialidadeFunction
    {
        IBuildChallengerConfiguration _buildConfiguration;
        ServiceProvider _serviceProvider;
        IEspecialidadeService _especialidadeService;

        public EspecialidadeFunction()
        {
            _serviceProvider = BuildServices();
            _buildConfiguration = _serviceProvider.GetService<IBuildChallengerConfiguration>();
            _especialidadeService = _serviceProvider.GetService<IEspecialidadeService>();
        }

        public async Task<IEnumerable<EspecialidadeResponse>> GetEspecialidadesAsync()
            => await _especialidadeService.BuscarEspecialidadeAsync();

        public async Task<IEnumerable<MedicoResponse>> GetMedicosEspecialidadeAsync(EspecialidadeMedicoRequest request)
        {
            var isEspecialidade = int.TryParse(request.IdEspecialidade, out int idEspecialidade);
            return isEspecialidade ? await _especialidadeService.ObterMedicoEspecilidade(idEspecialidade) : Enumerable.Empty<MedicoResponse>();
        }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBuildChallengerConfiguration, BuildChallengerConfiguration>();
            serviceCollection.AddDependencyRepository();
            serviceCollection.AddDependencyServices();
        }

        private ServiceProvider BuildServices()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
