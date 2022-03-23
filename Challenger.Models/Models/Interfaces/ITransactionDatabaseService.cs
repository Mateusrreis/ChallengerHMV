using System.Threading.Tasks;

namespace Challenger.Models.Models.Interfaces
{
    public interface ITransactionDatabaseService
    {
        Task CommitTransactionDatabase();
    }
}
