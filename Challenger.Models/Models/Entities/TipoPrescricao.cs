using System.Collections.Generic;



namespace Challenger.Models.Models.Entities
{
    public class TipoPrescricao
    {
        public TipoPrescricao()
        {
            Prescricao = new HashSet<Prescricao>();
        }

        public int IdTipoPrescricao { get; set; }
        public string StrTipoPrescricao { get; set; }

        public virtual ICollection<Prescricao> Prescricao { get; set; }
    }
}
