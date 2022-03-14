using Challenger.Models.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenger.Models.Models.Interfaces
{
    public interface IAgendamentoConsultaRepository
    {
        Task<IEnumerable<AgendaConsulta>> VerificarAgendaConsulta(DateTime dateConsultaInicio, DateTime dateConsultaFim);
        Task<IEnumerable<AgendaConsulta>> VerificarAgendaConsulta(DateTime dateConsulta);
        Task<AgendaConsulta> InserirAgendamento(AgendaConsulta agendaConsulta);
        Task<AgendaConsulta> BuscarAgendaConsulta(int idAgendaConsulta);
    }
}
