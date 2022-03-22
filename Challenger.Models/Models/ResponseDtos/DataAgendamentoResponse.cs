using System;

namespace Challenger.Models.Models.ResponseDtos
{
    public class DataAgendamentoResponse
    {
        protected DataAgendamentoResponse(DateTime dtAgendamento, int idMedico, int idAgenda, string nomeMedico)
        {
            DtAgendamento = dtAgendamento;
            IdMedico = idMedico;
            IdAgenda = idAgenda;
            NomeMedico = nomeMedico;
        }

        public int IdAgenda { get; set; }
        public DateTime DtAgendamento { get; set; }
        public int IdMedico { get; set; }
        public string NomeMedico { get; set; }

        public static class Builder
        {
            public static DataAgendamentoResponse Create(DateTime dtAgendamento, int idMedico, int idAgenda, string nomeMedico)
                => new DataAgendamentoResponse(dtAgendamento, idMedico, idAgenda, nomeMedico);
        }
    }
}
