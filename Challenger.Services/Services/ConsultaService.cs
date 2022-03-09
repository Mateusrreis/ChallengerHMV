using Challenger.Models;
using Challenger.Models.Entities;
using Challenger.Models.Models.Interfaces;
using Challenger.Repository.Interfaces;
using Challenger.Services.Interfaces;
using CreateTokenLambda.Models.ResponseDtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Challenger.Services.Services
{
    public class ConsultaServices : IConsultaServices
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IAtendimentoRepository _atendimentoRepository;

        public ConsultaServices(IConsultaRepository consultaRepository, IAtendimentoRepository atendimentoRepository)
        {
            _consultaRepository = consultaRepository;
            _atendimentoRepository = atendimentoRepository;
        }

        public async Task<AgendamentoConsultaResponse> MarcarConsulta(CalendarConsultaRequest calendarConsultaRequest)
        {
            var consulta = Consulta.Builder.Criar(calendarConsultaRequest.IdMedico,
                calendarConsultaRequest.DtConsulta,
                null,
                calendarConsultaRequest.IdPrescricao,
                calendarConsultaRequest.IdAtendimento
                );

            var atendimento = await _atendimentoRepository.BuscarAtendimento(consulta.IdAtendimento);
            if (await VerificarDisponibilidadeAgendamento(consulta.DtConsulta, TimeSpan.FromMinutes(30)))
            {
                var result = await _consultaRepository.CadastrarConsulta(consulta);

                return AgendamentoConsultaResponse.Builder.Criar(
                    agendado: result,
                    idPaciente: atendimento.IdPaciente,
                    idMedico: calendarConsultaRequest.IdMedico,
                    dtAgendamento: calendarConsultaRequest.DtConsulta,
                    createdIn: DateTime.Now
                    );
            }

            return AgendamentoConsultaResponse.Builder.Criar(
                    agendado: false,
                    idPaciente: atendimento.IdPaciente,
                    idMedico: calendarConsultaRequest.IdMedico,
                    dtAgendamento: calendarConsultaRequest.DtConsulta,
                    createdIn: DateTime.Now
                    );
        }

        private async Task<bool> VerificarDisponibilidadeAgendamento(DateTime dtConsulta, TimeSpan timeSpan)
        {
            var consultaRecente = await _consultaRepository.BuscarConsulta(dtConsulta);
            consultaRecente.Where(data => dtConsulta >= data.DtConsulta && dtConsulta <= data.DtConsulta.AddMinutes(timeSpan.Minutes));
            if (consultaRecente.Any()) return false;
            return true;
        }
    }
}
