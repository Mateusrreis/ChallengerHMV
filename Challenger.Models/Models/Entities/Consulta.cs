using System;


namespace Challenger.Repository
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public string IdMedico { get; set; }
        public DateTime? DtConsulta { get; set; }
        public string StrRelatorioMedico { get; set; }
        public int? IdPrescricao { get; set; }
        public int? IdAtendimento { get; set; }
        public bool? FlgTeleconsulta { get; set; }
        public string StrPlataformaTeleconsulta { get; set; }

        public virtual Atendimento IdAtendimentoNavigation { get; set; }
        public virtual Prescricao IdPrescricaoNavigation { get; set; }
    }
}
