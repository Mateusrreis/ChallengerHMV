using System;

namespace CreateTokenLambda.Models.ResponseDtos
{
    public class AgendamentoConsultaResponse
    {
        public AgendamentoConsultaResponse(bool agendado, int idPaciente, int idMedico, DateTime dtAgendamento, DateTime createdIn)
        {
            Agendado = agendado;
            IdPaciente = idPaciente;
            IdMedico = idMedico;
            CreatedIn = createdIn;
        }

        public bool Agendado { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public DateTime DtAgendamento { get; set; }
        public DateTime CreatedIn { get; set; }

        public static class Builder
        {
            public static AgendamentoConsultaResponse Criar(bool agendado, int idPaciente, int idMedico, DateTime dtAgendamento, DateTime createdIn)
                => new AgendamentoConsultaResponse(agendado, idPaciente, idMedico, dtAgendamento, createdIn);
        }
    }
}
