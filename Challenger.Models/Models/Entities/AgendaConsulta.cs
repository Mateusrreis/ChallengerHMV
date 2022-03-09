using System;

namespace Challenger.Models.Models.Entities
{
    public class AgendaConsulta
    {
        public int IdAgendaConsulta { get; set; }
        public int IdPaciente { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime DtConsulta { get; set; }
        public DateTime HrConsulta { get; set; }
        public int MinsDuracaoConsulta { get; set; }
        public int IdEspecialidade { get; set; }
        public int IdMedico { get; set; }
    }
}
