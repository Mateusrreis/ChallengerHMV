using Challenger.Models.Models.RequestDtos.Enums;

namespace Challenger.Models
{
    public class CalendarConsultaRequest
    {
        public int IdUsuario { get; set; }
        public int IdAgenda { get; set; }
        public TipoAgendamento TipoAgendamento { get; set; }
    }
}
