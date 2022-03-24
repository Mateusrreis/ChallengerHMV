using Amazon.Lambda.Core;
using Challenger.DependencyInjection;
using Challenger.DependencyInjection.Dependencies;
using Challenger.Models;
using Challenger.Models.Models.Interfaces;
using Challenger.Models.Models.RequestDtos;
using Challenger.Models.Models.ResponseDtos;
using Challenger.Services.Configuration;
using CreateTokenLambda.Models.ResponseDtos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SolucionChallenger
{
    public class AgendamentoFunction
    {
        IBuildChallengerConfiguration _buildConfiguration;
        ServiceProvider _serviceProvider;
        IConsultaServices _consultaServices;
        ITransactionDatabaseService _transactionDatabaseService;

        public AgendamentoFunction()
        {
            _serviceProvider = BuildServices();
            _buildConfiguration = _serviceProvider.GetService<IBuildChallengerConfiguration>();
            _consultaServices = _serviceProvider.GetService<IConsultaServices>();
            _transactionDatabaseService = _serviceProvider.GetService<ITransactionDatabaseService>();
        }

        public async Task<AgendamentoConsultaResponse> AgendarConsultaAsync(CalendarConsultaRequest input)
        {
            try
            {
                var consulta = await _consultaServices.MarcarConsultaAsync(input);
                if (consulta.Agendado) await _transactionDatabaseService.CommitTransactionDatabase();
                return consulta;
            }
            catch (Exception ex)
            {
                LambdaLogger.Log($@"{nameof(AgendamentoFunction)} - {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<DataAgendamentoResponse>> GetPacienteRequestAsync(AgendamentoPacienteRequest agendamentoRequest)
        {
            var isUsuario = int.TryParse(agendamentoRequest.IdUsuario, out int idUsuario);
            if (!isUsuario) Enumerable.Empty<IEnumerable<DataAgendamentoResponse>>();
            var dataAgendamento = await _consultaServices.VerificarConsultasAgendadasPacienteAsync(idUsuario);
            return dataAgendamento;
        }

        public async Task<IEnumerable<DataAgendamentoResponse>> GetAgendamentoConsultasAsync(AgendamentoRequest agendamentoRequest)
        {
            var consultas = await _consultaServices.VerificarConsultasAgendadasAsync(agendamentoRequest);
            return consultas;
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
