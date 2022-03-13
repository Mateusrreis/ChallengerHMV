using System;


namespace Challenger.Repository
{
    public partial class AgendaExame
    {
        public int IdAgendaExame { get; set; }
        public DateTime? DtCadastro { get; set; }
        public int? IdPaciente { get; set; }
        public DateTime? DtExame { get; set; }
        public DateTime? HrExame { get; set; }
        public int? IntMinsDuracaoExame { get; set; }
        public int? IdMedico { get; set; }
        public int? IdTipoExame { get; set; }

        public virtual Usuario IdPacienteNavigation { get; set; }
        public virtual TipoExame IdTipoExameNavigation { get; set; }
        public virtual Exame Exame { get; set; }
    }
}
