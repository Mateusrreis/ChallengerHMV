using System.Collections.Generic;



namespace Challenger.Repository
{
    public partial class TipoPrescricao
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
