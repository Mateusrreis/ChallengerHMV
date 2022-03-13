using System;

namespace Challenger.Models.Models.ResponseDtos
{
    public class DataAgendamentoResponse
    {
        protected DataAgendamentoResponse(DateTime dtAgendamento, int idMedico, DateTime hrConsulta)
        {
            DtAgendamento = dtAgendamento;
            IdMedico = idMedico;
            HrConsulta = hrConsulta;
        }

        public DateTime DtAgendamento { get; set; }
        public int IdMedico { get; set; }
        public DateTime HrConsulta { get; set; }

        public static class Builder
        {
            public static DataAgendamentoResponse Create(DateTime dtAgendamento, int idMedico, DateTime hrConsulta)
                => new DataAgendamentoResponse(dtAgendamento, idMedico, hrConsulta);
        }
    }
}
