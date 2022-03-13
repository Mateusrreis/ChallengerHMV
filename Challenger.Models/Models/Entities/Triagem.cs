using System;



namespace Challenger.Repository
{
    public partial class Triagem
    {
        public int IdTriagem { get; set; }
        public DateTime? DtTriagem { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdEnfermeiro { get; set; }
        public string StrSintomas { get; set; }
        public int? IntPressaoArterialMax { get; set; }
        public int? IntPressaoArterialMin { get; set; }
        public decimal? DecTemperatura { get; set; }
        public decimal? DecSaturacao { get; set; }
        public int? IntClassificacao { get; set; }
        public int? IntDor { get; set; }
        public int? IdConsulta { get; set; }
    }
}
