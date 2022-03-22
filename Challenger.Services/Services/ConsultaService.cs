using Challenger.Models;
using Challenger.Models.Models.Entities;
using Challenger.Models.Models.Interfaces;
using Challenger.Models.Models.RequestDtos;
using Challenger.Models.Models.ResponseDtos;
using CreateTokenLambda.Models.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenger.Services.Services
{
    public class ConsultaServices : IConsultaServices
    {
        private readonly IAgendamentoConsultaRepository _agendamentoConsultaRepository;
        private readonly IBuildChallengerConfiguration _configuration;

        public ConsultaServices(IAgendamentoConsultaRepository agendamentoConsultaRepository, IBuildChallengerConfiguration configuration)
        {
            _agendamentoConsultaRepository = agendamentoConsultaRepository;
            _configuration = configuration;
        }

        public async Task<AgendamentoConsultaResponse> MarcarConsulta(CalendarConsultaRequest calendarConsultaRequest)
        {
            var duration = TimeSpan.FromMinutes(Convert.ToDouble(_configuration.Configuration["duracaoConsulta"]));
            AgendamentoConsultaResponse consultaResponse = AgendamentoConsultaResponse.Builder.Criar(false, calendarConsultaRequest.IdMedico, calendarConsultaRequest.DtConsulta, DateTime.Now);
            if (!await VerificarDisponibilidadeAgendamento(calendarConsultaRequest.DtConsulta, duration))
            {
                var agendamento = AgendaConsulta.Builder.Create(calendarConsultaRequest.DtConsulta, calendarConsultaRequest.DtConsulta, duration.Minutes, calendarConsultaRequest.IdMedico);
                var consulta = await _agendamentoConsultaRepository.InserirAgendamento(agendamento);
                consultaResponse = AgendamentoConsultaResponse.Builder.Criar(true, consulta.IdMedico.Value, consulta.DtConsulta.Value, DateTime.Now);
            }
            return consultaResponse;
        }

        public async Task<IEnumerable<DataAgendamentoResponse>> VerificarConsultasAgendadasAsync(AgendamentoRequest agendamentoRequest)
        {
            var datasAgendamentos = new List<DataAgendamentoResponse>();
            var agendamentoConsulta = new List<AgendaConsulta>();
            if (!int.TryParse(agendamentoRequest.IdEspecialidade, out int especialidade)) Enumerable.Empty<DataAgendamentoResponse>();
            if (agendamentoRequest.IdMedico is null)
            {
                agendamentoConsulta = (await _agendamentoConsultaRepository.VerificarAgendaConsultaEspecialidade(agendamentoRequest.DtAgendamentoInicio, agendamentoRequest.DtAgendamentoFim, especialidade)).ToList();
            }
            else
            {
                if (!int.TryParse(agendamentoRequest.IdMedico, out int medico)) Enumerable.Empty<DataAgendamentoResponse>();
                agendamentoConsulta = (await _agendamentoConsultaRepository.VerificarAgendaConsultaMedico(agendamentoRequest.DtAgendamentoInicio, agendamentoRequest.DtAgendamentoFim, medico)).ToList();
            }

            foreach (var agenda in agendamentoConsulta)
                datasAgendamentos.Add(DataAgendamentoResponse.Builder.Create(agenda.HrConsulta.Value, agenda.IdMedico.Value, agenda.IdAgendaConsulta, agenda.idMedicoNavigation.UsuarioMap.StrUsuario));

            return datasAgendamentos;
        }

        private async Task<bool> VerificarDisponibilidadeAgendamento(DateTime horaConsulta, TimeSpan timeSpan)
        {
            var agendamentoConsulta = await _agendamentoConsultaRepository.VerificarAgendaConsulta(horaConsulta);
            var validacaoAgendamento = agendamentoConsulta.Any(e => horaConsulta >= e.HrConsulta && horaConsulta <= e.HrConsulta.Value.AddMinutes(timeSpan.Minutes));
            return validacaoAgendamento;
        }
    }
}
