using Challenger.Models.Models.Entities;
using System.Threading.Tasks;

namespace Challenger.Models.Interfaces
{
    public interface IConsultaRepository
    {
        Task<bool> AgendarConsulta(Consulta consulta);
    }
}
