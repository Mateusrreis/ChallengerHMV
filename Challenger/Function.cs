using Amazon.Lambda.Core;
using Challenger;
using Challenger.DependencyInjection;
using Challenger.DependencyInjection.Dependencies;
using Challenger.Interfaces;
using Challenger.Models;
using Challenger.Services.Interfaces;
using CreateTokenLambda.Models.ResponseDtos;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SolucionChallenger
{
    public class Function
    {
        IBuildChallengerConfiguration _buildConfiguration;
        ServiceProvider _serviceProvider;
        IConsultaServices _consultaServices;

        public Function()
        {
            _serviceProvider = BuildServices();
            _buildConfiguration = _serviceProvider.GetService<IBuildChallengerConfiguration>();
            _consultaServices = _serviceProvider.GetService<IConsultaServices>();
        }

        public async Task<AgendamentoConsultaResponse> AgendarConsultaAsync(CalendarConsultaRequest input)
        {
            return await _consultaServices.MarcarConsulta(input);
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
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
