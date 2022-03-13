using Challenger.Models;
using Challenger.Models.Models.Entities;
using Challenger.Models.Models.Interfaces;
using CreateTokenLambda.Models.ResponseDtos;
using System;
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

        private async Task<bool> VerificarDisponibilidadeAgendamento(DateTime horaConsulta, TimeSpan timeSpan)
        {
            var agendamentoConsulta = await _agendamentoConsultaRepository.VerificarAgendaConsulta(horaConsulta);
            var validacaoAgendamento = agendamentoConsulta.Any(e => horaConsulta >= e.HrConsulta && horaConsulta <= e.HrConsulta.Value.AddMinutes(timeSpan.Minutes));
            return validacaoAgendamento;
        }
    }
}
