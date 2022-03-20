using Challenger.Models.Interfaces;
using Challenger.Models.Models.Interfaces;
using Challenger.Models.Models.ResponseDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenger.Services.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly IMedicoRepository _medicoRepository;

        public EspecialidadeService(IEspecialidadeRepository especialidadeRepository, IMedicoRepository medicoRepository)
        {
            _especialidadeRepository = especialidadeRepository;
            _medicoRepository = medicoRepository;
        }

        public async Task<IEnumerable<EspecialidadeResponse>> BuscarEspecialidadeAsync()
        {
            var especialidadesResults = new List<EspecialidadeResponse>();
            var especialidades = await _especialidadeRepository.ObterEspecialidadesAsync();
            foreach (var especialidade in especialidades)
                especialidadesResults.Add(EspecialidadeResponse.Builder.Criar(especialidade.IdEspecialidade, especialidade.StrEspecialidade));
            return especialidadesResults;
        }

        public async Task<IEnumerable<MedicoResponse>> ObterMedicoEspecilidade(int idEspecialidade)
        {
            var medicos = new List<MedicoResponse>();
            var userMedicos = await _medicoRepository.ObterMedicosPorEspecialidade(idEspecialidade);
            foreach (var user in userMedicos)
                medicos.Add(MedicoResponse.Builder.Criar(user.IdMedico, user.UsuarioMap.StrUsuario));
            return medicos;
        }
    }
}
