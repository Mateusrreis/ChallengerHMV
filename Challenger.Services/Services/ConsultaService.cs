using Amazon.Lambda.Core;
using Challenger.Models;
using Challenger.Models.Models.Entities;
using Challenger.Models.Models.Interfaces;
using Challenger.Models.Models.RequestDtos;
using Challenger.Models.Models.RequestDtos.Enums;
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

        public async Task<AgendamentoConsultaResponse> MarcarConsultaAsync(CalendarConsultaRequest calendarConsultaRequest)
        {
            LambdaLogger.Log($@"{nameof(ConsultaServices)} - {calendarConsultaRequest}");
            if (!calendarConsultaRequest.TipoAgendamento.IsExame())
            {
                var agendaConsulta = await _agendamentoConsultaRepository.BuscarAgendaConsulta(calendarConsultaRequest.IdAgenda);
                LambdaLogger.Log($@"{nameof(ConsultaServices)} - {agendaConsulta.IdAgendaConsulta}");
                if (agendaConsulta.IdUsuario.HasValue) return AgendamentoConsultaResponse.Builder.Criar(false, 0, DateTime.Now, DateTime.Now, calendarConsultaRequest.TipoAgendamento.ToString());
                agendaConsulta.SetIdUsuario(calendarConsultaRequest.IdUsuario);
                var consulta = _agendamentoConsultaRepository.AtualizarAgendamento(agendaConsulta);
                return AgendamentoConsultaResponse.Builder.Criar(true, consulta.IdMedico.Value, consulta.DtConsulta.Value, DateTime.Now, calendarConsultaRequest.TipoAgendamento.ToString());
            }
            LambdaLogger.Log($@"{nameof(ConsultaServices)} - {calendarConsultaRequest.TipoAgendamento}");
            return AgendamentoConsultaResponse.Builder.Criar(false, 0, DateTime.Now, DateTime.Now, calendarConsultaRequest.TipoAgendamento.ToString());
        }

        public async Task<IEnumerable<DataAgendamentoResponse>> VerificarConsultasAgendadasAsync(AgendamentoRequest agendamentoRequest)
        {
            var datasAgendamentos = new List<DataAgendamentoResponse>();
            var agendamentoConsulta = new List<AgendaConsulta>();
            if (!int.TryParse(agendamentoRequest.IdEspecialidade, out int especialidade)) Enumerable.Empty<DataAgendamentoResponse>();
            if (string.IsNullOrEmpty(agendamentoRequest.IdMedico))
            {
                agendamentoConsulta = (await _agendamentoConsultaRepository.VerificarAgendaConsultaEspecialidade(agendamentoRequest.GetAgendamentoInicio(), agendamentoRequest.GetAgendamentoFim(), especialidade)).ToList();
            }
            else
            {
                if (!int.TryParse(agendamentoRequest.IdMedico, out int medico)) Enumerable.Empty<DataAgendamentoResponse>();
                agendamentoConsulta = (await _agendamentoConsultaRepository.VerificarAgendaConsultaMedico(agendamentoRequest.GetAgendamentoInicio(), agendamentoRequest.GetAgendamentoFim(), medico)).ToList();
            }

            foreach (var agenda in agendamentoConsulta)
                datasAgendamentos.Add(DataAgendamentoResponse.Builder.Create(agenda.HrConsulta.Value, agenda.IdMedico.Value, agenda.IdAgendaConsulta, agenda.idMedicoNavigation.UsuarioMap.StrUsuario));

            return datasAgendamentos;
        }

        public async Task<IEnumerable<DataAgendamentoResponse>> VerificarConsultasAgendadasPacienteAsync(int idUsuario)
        {
            var datasAgendamentos = new List<DataAgendamentoResponse>();
            var agendamentoUsuarios = await _agendamentoConsultaRepository.BuscarAgendaConsultaPacienteAsync(idUsuario);
            foreach (var agendamentoUsuario in agendamentoUsuarios)
                datasAgendamentos.Add(DataAgendamentoResponse.Builder.Create(agendamentoUsuario.HrConsulta.Value, agendamentoUsuario.IdMedico.Value, agendamentoUsuario.IdAgendaConsulta, agendamentoUsuario.idMedicoNavigation.UsuarioMap.StrUsuario));
            return datasAgendamentos;
        }
    }
}
