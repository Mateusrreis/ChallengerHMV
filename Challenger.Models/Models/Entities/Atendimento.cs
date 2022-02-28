using System;

namespace Challenger.Models.Models.Entities
{
    public class Atendimento
    {
        public int IdAtendimento { get; set; }
        public DateTime DtAtendimento { get; set; }
        public int IdPaciente { get; set; }
        public int IdConvenio { get; set; }
        public float CodCartaoConvenio { get; set; }
        public string StrConvenioCategoria { get; set; }
        public bool FlgParticular { get; set; }
    }
}
