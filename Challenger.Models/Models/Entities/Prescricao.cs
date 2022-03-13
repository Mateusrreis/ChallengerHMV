using System.Collections.Generic;


namespace Challenger.Models.Models.Entities
{
    public class Prescricao
    {
        public Prescricao()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdPrescricao { get; set; }
        public int? IdTipoPrescricao { get; set; }
        public string StrObservacao { get; set; }
        public bool? FlgRetorno { get; set; }
        public int? IntDiasRetorno { get; set; }
        public string UrlReceituario { get; set; }
        public string UrlGuiaExame { get; set; }
        public string UrlAtestado { get; set; }

        public virtual TipoPrescricao IdTipoPrescricaoNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
