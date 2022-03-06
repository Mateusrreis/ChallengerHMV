using System;

namespace Challenger.Models.Entities
{
    public class Consulta
    {
        public Consulta()
        {
        }

        protected Consulta(int idMedico, DateTime dtConsulta, string relatorioMedico, int idPrescricao, int idAtendimento)
        {
            IdMedico = idMedico;
            DtConsulta = dtConsulta;
            RelatorioMedico = relatorioMedico;
            IdPrescricao = idPrescricao;
            IdAtendimento = idAtendimento;
        }

        public int IdConsulta { get; protected set; }
        public int IdMedico { get; protected set; }
        public DateTime DtConsulta { get; protected set; }
        public string RelatorioMedico { get; protected set; }
        public int IdPrescricao { get; protected set; }
        public int IdAtendimento { get; protected set; }

        public static class Builder
        {
            public static Consulta Criar(int idMedico, DateTime dtConsulta, string relatorioMedico, int idPrescricao, int idAtendimento)
                => new Consulta(idMedico, dtConsulta, relatorioMedico, idPrescricao, idAtendimento);
        }
    }
}
