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

        public ConsultaServices(IAgendamentoConsultaRepository agendamentoConsultaRepository)
        {
            _agendamentoConsultaRepository = agendamentoConsultaRepository;
        }

        public async Task<AgendamentoConsultaResponse> MarcarConsulta(CalendarConsultaRequest calendarConsultaRequest)
        {
            var duration = TimeSpan.FromMinutes(30);
            AgendamentoConsultaResponse consultaResponse = AgendamentoConsultaResponse.Builder.Criar(false, calendarConsultaRequest.IdMedico, calendarConsultaRequest.DtConsulta, DateTime.Now); ;
            if (!await VerificarDisponibilidadeAgendamento(calendarConsultaRequest.DtConsulta, duration))
            {
                var agendamento = AgendaConsulta.Builder.Create(calendarConsultaRequest.DtConsulta, calendarConsultaRequest.DtConsulta, duration.Minutes, calendarConsultaRequest.IdMedico);
                var consulta = await _agendamentoConsultaRepository.InserirAgendamento(agendamento);
                consultaResponse = AgendamentoConsultaResponse.Builder.Criar(true, consulta.IdMedico.Value, consulta.DtConsulta.Value, DateTime.Now);
            }
            return consultaResponse;
        }

        public async Task<IEnumerable<DataAgendamentoResponse>> VerificarConsultasAgendadas(AgendamentoRequest agendamentoRequest)
        {
            var agendaConsultas = new List<DataAgendamentoResponse>();
            var agendamento = await _agendamentoConsultaRepository.VerificarAgendaConsulta(agendamentoRequest.DtAgendamentoInicio, agendamentoRequest.DtAgendamentoFim);
            foreach (var agenda in agendamento)
                agendaConsultas.Add(DataAgendamentoResponse.Builder.Create(agenda.DtConsulta.Value, agenda.IdMedico.Value, agenda.HrConsulta.Value));
            return agendaConsultas;
        }

        private async Task<bool> VerificarDisponibilidadeAgendamento(DateTime horaConsulta, TimeSpan timeSpan)
        {
            var agendamentoConsulta = await _agendamentoConsultaRepository.VerificarAgendaConsulta(horaConsulta);
            var validacaoAgendamento = agendamentoConsulta.Any(e => horaConsulta >= e.HrConsulta && horaConsulta <= e.HrConsulta.Value.AddMinutes(timeSpan.Minutes));
            return validacaoAgendamento;
        }
    }
}
