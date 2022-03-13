using Challenger.Models.Models.RequestDtos;
using Challenger.Models.Models.ResponseDtos;
using CreateTokenLambda.Models.ResponseDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenger.Models.Models.Interfaces
{
    public interface IConsultaServices
    {
        Task<AgendamentoConsultaResponse> MarcarConsulta(CalendarConsultaRequest calendarConsultaRequest);
        Task<IEnumerable<DataAgendamentoResponse>> VerificarConsultasAgendadas(AgendamentoRequest agendamentoRequest);
    }
}
