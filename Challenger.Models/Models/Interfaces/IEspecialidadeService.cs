using Challenger.Models.Models.ResponseDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenger.Models.Models.Interfaces
{
    public interface IEspecialidadeService
    {
        Task<IEnumerable<EspecialidadeResponse>> BuscarEspecialidadeAsync();
        Task<IEnumerable<MedicoResponse>> ObterMedicoEspecilidade(int idEspecialidade);
    }
}
