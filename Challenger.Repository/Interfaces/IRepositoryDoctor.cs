using Challenger.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenger.Repository.Interfaces
{
    public interface IRepositoryDoctor
    {
        Task<IEnumerable<Medico>> GetDoctorsAsync(int idDoctor);
    }
}
