using Challenger.Models.Models.RequestDtos;
using Challenger.Models.Models.ResponseDtos;
using CreateTokenLambda.Models.ResponseDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenger.Models.Models.Interfaces
{
    public interface IConsultaServices
    {
        Task<AgendamentoConsultaResponse> MarcarConsultaAsync(CalendarConsultaRequest calendarConsultaRequest);
        Task<IEnumerable<DataAgendamentoResponse>> VerificarConsultasAgendadasAsync(AgendamentoRequest agendamentoRequest);
        Task<IEnumerable<DataAgendamentoResponse>> VerificarConsultasAgendadasPacienteAsync(int agendamentoRequest);
    }
}
