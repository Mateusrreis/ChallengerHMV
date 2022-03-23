using System;

namespace Challenger.Models.Models.RequestDtos
{
    public class AgendamentoRequest
    {
        public DateTime DtAgendamentoInicio { get; set; }
        public DateTime DtAgendamentoFim { get; set; }
        public string IdEspecialidade { get; set; }
        public string IdMedico { get; set; }
    }
}
