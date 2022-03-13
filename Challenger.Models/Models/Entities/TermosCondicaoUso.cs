using System;


namespace Challenger.Models.Models.Entities
{
    public class TermosCondicaoUso
    {
        public int IdTermosCondicaoUso { get; set; }
        public string StrTermosCondicaoUso { get; set; }
        public int? IdPerfil { get; set; }
        public DateTime? DtInicioVigencia { get; set; }
        public DateTime? DtFimVigencia { get; set; }
    }
}
