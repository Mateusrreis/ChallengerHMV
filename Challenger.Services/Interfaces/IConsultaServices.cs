using Challenger.Models;
using CreateTokenLambda.Models.ResponseDtos;
using System.Threading.Tasks;

namespace Challenger.Services.Interfaces
{
    public interface IConsultaServices
    {
        Task<AgendamentoConsultaResponse> MarcarConsulta(CalendarConsultaRequest calendarConsultaRequest);
    }
}
