using System;
using System.Collections.Generic;

namespace Challenger.Repository
{
    public partial class Atendimento
    {
        public Atendimento()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdAtendimento { get; set; }
        public DateTime? DtAtendimento { get; set; }
        public int? IdConvenio { get; set; }
        public float? CodCartaoConvenio { get; set; }
        public string StrConvenioCategoria { get; set; }
        public bool? FlgParticular { get; set; }
        public int? IdConsulta { get; set; }
        public int? IdAgendaConsulta { get; set; }

        public virtual AgendaConsulta IdAgendaConsultaNavigation { get; set; }
        public virtual Convenio IdConvenioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
