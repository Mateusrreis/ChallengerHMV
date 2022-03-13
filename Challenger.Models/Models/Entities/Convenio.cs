using System.Collections.Generic;



namespace Challenger.Models.Models.Entities
{
    public class Convenio
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
