using Challenger.Models.Entities;
using System.Threading.Tasks;

namespace Challenger.Repository.Interfaces
{
    public interface IConsultaRepository
    {
        Task<bool> AgendarConsulta(Consulta consulta);
    }
}
