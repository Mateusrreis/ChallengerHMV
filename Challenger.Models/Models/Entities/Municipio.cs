using System.Collections.Generic;



namespace Challenger.Repository
{
    public partial class Municipio
    {
        public Municipio()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdMunicipio { get; set; }
        public int? IdEstado { get; set; }
        public string StrMunicipio { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
