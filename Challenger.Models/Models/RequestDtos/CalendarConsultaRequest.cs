using System;

namespace Challenger.Models
{
    public class CalendarConsultaRequest
    {
        public DateTime DtConsulta { get; set; }
        public int IdMedico { get; set; }
        public int IdConsulta { get; set; }
        public int IdPrescricao { get; set; }
        public int IdAtendimento { get; set; }
    }
}
