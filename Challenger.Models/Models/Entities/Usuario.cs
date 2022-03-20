using System.Collections.Generic;

namespace Challenger.Models.Models.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            AgendaExame = new HashSet<AgendaExame>();
            Medico = new HashSet<Medico>();
        }

        public int IdUsuario { get; set; }
        public string StrUsuario { get; set; }
        public float FltCpf { get; set; }
        public float? FltCelular { get; set; }
        public string StrEndereco { get; set; }
        public int? IntEnderecoNum { get; set; }
        public string StrEnderecoCompleto { get; set; }
        public string StrEnderecoBairro { get; set; }
        public int? IdEnderecoMunicipio { get; set; }
        public float? FltEnderecoCep { get; set; }
        public string StrEmail { get; set; }
        public bool? FlgMedico { get; set; }
        public bool? FlgPaciente { get; set; }

        public virtual Municipio IdEnderecoMunicipioNavigation { get; set; }
        public virtual ICollection<AgendaExame> AgendaExame { get; set; }
        public virtual ICollection<Medico> Medico { get; set; }
    }
}
