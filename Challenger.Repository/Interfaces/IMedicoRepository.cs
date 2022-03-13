using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenger.Repository.Interfaces
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetDoctorsAsync(int idDoctor);
    }
}
