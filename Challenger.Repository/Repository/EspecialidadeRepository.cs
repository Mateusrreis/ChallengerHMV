using Challenger.Models.Models.Entities;
using Challenger.Models.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenger.Repository.Repository
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private HMVContext _hMVContext;

        public EspecialidadeRepository(HMVContext hMVContext) => _hMVContext = hMVContext;

        public async Task<IEnumerable<Especialidade>> ObterEspecialidadesAsync()
            => await _hMVContext.Especialidade.AsQueryable().ToListAsync();
    }
}
