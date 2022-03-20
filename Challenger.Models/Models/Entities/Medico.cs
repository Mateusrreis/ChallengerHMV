using System.Collections.Generic;

namespace Challenger.Models.Models.Entities
{
    public class Medico
    {
        public int IdMedico { get; set; }
        public int? IdUsuario { get; set; }
        public float? FltCrm { get; set; }
        public int? IdEspecialidade { get; set; }
        public Usuario UsuarioMap { get; set; }
        public virtual ICollection<AgendaConsulta> AgendaConsulta { get; set; }
    }
}
