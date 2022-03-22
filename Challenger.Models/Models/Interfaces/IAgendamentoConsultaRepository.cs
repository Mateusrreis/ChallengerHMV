using Challenger.Models.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenger.Models.Models.Interfaces
{
    public interface IAgendamentoConsultaRepository
    {
        Task<IEnumerable<AgendaConsulta>> VerificarAgendaConsultaEspecialidade(DateTime dateConsultaInicio, DateTime dateConsultaFim, int idEspecialidade);
        Task<IEnumerable<AgendaConsulta>> VerificarAgendaConsultaMedico(DateTime dateConsultaInicio, DateTime dateConsultaFim, int idMedico);
        Task<IEnumerable<AgendaConsulta>> VerificarAgendaConsulta(DateTime dateConsulta);
        Task<AgendaConsulta> InserirAgendamento(AgendaConsulta agendaConsulta);
        Task<AgendaConsulta> BuscarAgendaConsulta(int idAgendaConsulta);
    }
}
