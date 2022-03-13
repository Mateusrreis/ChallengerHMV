using System;
using System.Collections.Generic;


namespace Challenger.Repository
{
    public partial class AgendaConsulta
    {


        public AgendaConsulta()
        {
            Atendimento = new HashSet<Atendimento>();
        }

        protected AgendaConsulta(DateTime? dtConsulta, DateTime? hrConsulta, int? intMinsDuracaoConsulta, int? idMedico)
        {
            DtCadastro = DateTime.Now;
            DtConsulta = dtConsulta;
            HrConsulta = hrConsulta;
            IntMinsDuracaoConsulta = intMinsDuracaoConsulta;
            IdMedico = idMedico;
        }

        public int IdAgendaConsulta { get; set; }
        public DateTime? DtCadastro { get; set; }
        public DateTime? DtConsulta { get; set; }
        public DateTime? HrConsulta { get; set; }
        public int? IntMinsDuracaoConsulta { get; set; }
        public int? IdMedico { get; set; }
        public virtual Medico idMedicoNavigation { get; set; }
        public virtual ICollection<Atendimento> Atendimento { get; set; }

        public static class Builder
        {
            public static AgendaConsulta Create(DateTime dtConsulta, DateTime hrConsulta, int intMinsDuracaoConsulta, int idMedico) 
                => new AgendaConsulta(dtConsulta, hrConsulta, intMinsDuracaoConsulta, idMedico);
        }
    }
}
