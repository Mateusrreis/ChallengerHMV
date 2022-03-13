using System.Collections.Generic;



namespace Challenger.Models.Models.Entities
{
    public class TipoExame
    {
        public TipoExame()
        {
            AgendaExame = new HashSet<AgendaExame>();
        }

        public int IdTipoExame { get; set; }
        public string StrDescricao { get; set; }
        public string StrPreparoExame { get; set; }

        public virtual ICollection<AgendaExame> AgendaExame { get; set; }
    }
}
