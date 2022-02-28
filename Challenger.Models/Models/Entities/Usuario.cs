using System;
using System.Collections.Generic;
using System.Text;

namespace Challenger.Models.Models.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string StrUsuario { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }
        public int EnderecoNumero { get; set; }
        public string EnderecoCompleto { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoMunicipio { get; set; }
        public string EnderecoCEP { get; set; }
        public string Email { get; set; }
        public bool flgMedico { get; set; }
        public bool flgPaciente { get; set; }
    }
}
