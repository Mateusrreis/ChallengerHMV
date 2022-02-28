using Challenger.Models;
using Challenger.Models.Entities;
using Challenger.Repository.Interfaces;
using Challenger.Services.Interfaces;
using CreateTokenLambda.Models.ResponseDtos;
using System.Threading.Tasks;

namespace Challenger.Services.Services
{
    public class ConsultaServices : IConsultaServices
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaServices(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public async Task<AgendamentoConsultaResponse> MarcarConsulta(CalendarConsultaRequest calendarConsultaRequest)
        {
            var consulta = Consulta.Builder.Criar(calendarConsultaRequest.IdMedico,
                calendarConsultaRequest.DtConsulta,
                null,
                calendarConsultaRequest.IdPrescricao,
                calendarConsultaRequest.IdAtendimento
                );
            var result = await _consultaRepository.AgendarConsulta(consulta);

            if (result)
            {
                return AgendamentoConsultaResponse.Builder.Criar(
                    agendado: result,
                    idPaciente: 0,
                    idMedico: calendarConsultaRequest.IdMedico,
                    dtAgendamento: calendarConsultaRequest.DtConsulta,
                    createdIn: System.DateTime.Now
                    );
            }

            return null;
        }
    }
}
