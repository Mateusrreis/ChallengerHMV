using Challenger.Models.Models.Interfaces;
using Challenger.Models.Models.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Services.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeService(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }

        public async Task<IEnumerable<EspecialidadeResponse>> BuscarEspecialidadeAsync()
        {
            var especialidadesResults = new List<EspecialidadeResponse>();
            var especialidades = await _especialidadeRepository.ObterEspecialidadesAsync();
            foreach (var especialidade in especialidades)
                especialidadesResults.Add(EspecialidadeResponse.Builder.Criar(especialidade.IdEspecialidade, especialidade.StrEspecialidade));
            return especialidadesResults;
        }
    }
}
