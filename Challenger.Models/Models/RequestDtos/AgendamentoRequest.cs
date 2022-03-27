using System;

namespace Challenger.Models.Models.RequestDtos
{
    public class AgendamentoRequest
    {
        public string DtAgendamentoInicio { get; set; }
        public string DtAgendamentoFim { get; set; }
        public string IdEspecialidade { get; set; }
        public string IdMedico { get; set; }

        public void SetAgendamentoInicio(string dtAgendamentoInicio) => DtAgendamentoInicio = Uri.UnescapeDataString(dtAgendamentoInicio);
        public void SetAgendamentoFim(string dtAgendamentoFim) => DtAgendamentoFim = Uri.UnescapeDataString(dtAgendamentoFim);
        public DateTime GetAgendamentoInicio() => DateTime.Parse(DtAgendamentoInicio);
        public DateTime GetAgendamentoFim() => DateTime.Parse(DtAgendamentoFim);
    }
}
