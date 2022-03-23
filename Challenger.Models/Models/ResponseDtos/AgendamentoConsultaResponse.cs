using System;

namespace CreateTokenLambda.Models.ResponseDtos
{
    public class AgendamentoConsultaResponse
    {
        public AgendamentoConsultaResponse(bool agendado, int idMedico, DateTime dtAgendamento, DateTime createdIn, string tipoAgendamento)
        {
            Agendado = agendado;
            CreatedIn = createdIn;
            DtAgendamento = dtAgendamento;
            TipoAgendamento = tipoAgendamento;
        }

        public bool Agendado { get; set; }
        public int IdMedico { get; set; }
        public DateTime DtAgendamento { get; set; }
        public DateTime CreatedIn { get; set; }
        public string TipoAgendamento { get; set; }

        public static class Builder
        {
            public static AgendamentoConsultaResponse Criar(bool agendado, int idMedico, DateTime dtAgendamento, DateTime createdIn, string tipoAgendamento)
                => new AgendamentoConsultaResponse(agendado, idMedico, dtAgendamento, createdIn, tipoAgendamento);
        }
    }
}
