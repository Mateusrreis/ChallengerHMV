using Challenger.Models.Models.Entities;
using System.Threading.Tasks;

namespace Challenger.Models.Models.Interfaces
{
    public interface IAtendimentoRepository
    {
        Task<Atendimento> BuscarAtendimento(int idAtendimento);
    }
}
