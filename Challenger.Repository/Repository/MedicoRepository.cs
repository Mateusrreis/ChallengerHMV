using Amazon.Lambda.Core;
using Challenger.Models.Interfaces;
using Challenger.Models.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenger.Repository.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HMVContext _context;

        public MedicoRepository(HMVContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medico>> ObterMedicosPorEspecialidade(int idEspecialidade)
        {
            try
            {
                return await _context.Medico.Where(e => e.IdEspecialidade == idEspecialidade)
                     .Include(e => e.UsuarioMap)
                     .ToListAsync();
            }
            catch (Exception ex)
            {
                LambdaLogger.Log($@"{nameof(MedicoRepository)} - {ex.Message}");
                throw;
            }
        }
    }
}
