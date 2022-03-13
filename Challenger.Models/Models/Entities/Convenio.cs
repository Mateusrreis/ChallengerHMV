using System.Collections.Generic;



namespace Challenger.Repository
{
    public partial class Convenio
    {
        public Convenio()
        {
            Atendimento = new HashSet<Atendimento>();
        }

        public string StrConvenio { get; set; }
        public int IdConvenio { get; set; }

        public virtual ICollection<Atendimento> Atendimento { get; set; }
    }
}
