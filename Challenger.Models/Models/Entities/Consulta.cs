using System;

namespace Challenger.Models.Entities
{
    public class Consulta
    {
        public int IdConsulta { get; set; }
        public int IdMedico { get; set; }
        public DateTime DtConsulta { get; set; }
        public string RelatorioMedico { get; set; }
        public int idPrescricao { get; set; }
        public int idAtendimento { get; set; }
    }
}
