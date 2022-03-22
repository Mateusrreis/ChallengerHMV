using Amazon.Lambda.Core;
using Challenger.Models.Models.Entities;
using Challenger.Models.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Challenger.Repository.Repository
{
    public class AgendamentoConsultaRepository : IAgendamentoConsultaRepository
    {
        private HMVContext _hMVContext;

        public AgendamentoConsultaRepository(HMVContext context) => _hMVContext = context;

        public Task<AgendaConsulta> BuscarAgendaConsulta(int idAgendaConsulta)
        {
            throw new NotImplementedException();
        }

        public async Task<AgendaConsulta> InserirAgendamento(AgendaConsulta agendaConsulta)
        {
            try
            {
                var insertRows = await _hMVContext.AgendaConsulta.AddAsync(agendaConsulta);
                return insertRows.Entity;
            }
            catch (Exception ex)
            {
                LambdaLogger.Log($@"{nameof(AgendamentoConsultaRepository)} - {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<AgendaConsulta>> VerificarAgendaConsultaEspecialidade(DateTime dateConsultaInicio, DateTime dateConsultaFim, int idEspecialidade)
        {
            try
            {
                return await _hMVContext.AgendaConsulta.Where(e => e.HrConsulta.Value >= dateConsultaInicio && e.HrConsulta.Value <= dateConsultaFim && e.idMedicoNavigation.IdEspecialidade == idEspecialidade)
                                .Include(e => e.idMedicoNavigation)
                                .ThenInclude(e => e.UsuarioMap)
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                LambdaLogger.Log($@"{nameof(AgendamentoConsultaRepository)} - {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<AgendaConsulta>> VerificarAgendaConsulta(DateTime dateConsulta)
        {
            try
            {
                return await _hMVContext.AgendaConsulta.Where(e => e.DtConsulta.Value == dateConsulta.Date)
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                LambdaLogger.Log($@"{nameof(AgendamentoConsultaRepository)} - {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<AgendaConsulta>> VerificarAgendaConsultaMedico(DateTime dateConsultaInicio, DateTime dateConsultaFim, int idMedico)
        {
            try
            {
                return await _hMVContext.AgendaConsulta.Where(e => e.HrConsulta.Value >= dateConsultaInicio && e.HrConsulta.Value <= dateConsultaFim && e.idMedicoNavigation.IdMedico == idMedico)
                                .Include(e => e.idMedicoNavigation)
                                .ThenInclude(e => e.UsuarioMap)
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                LambdaLogger.Log($@"{nameof(AgendamentoConsultaRepository)} - {ex.Message}");
                throw;
            }

        }
    }
}
