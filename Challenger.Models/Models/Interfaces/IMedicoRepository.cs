using Challenger.Models.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenger.Models.Interfaces
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetDoctorsAsync(int idDoctor);
    }
}
