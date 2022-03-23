using Challenger.Models.Models.Interfaces;
using Challenger.Repository;
using System.Threading.Tasks;

namespace Challenger.Services.Services
{
    public class TransactionDatabaseService : ITransactionDatabaseService
    {
        private readonly HMVContext _context;

        public TransactionDatabaseService(HMVContext context)
        {
            _context = context;
        }

        public async Task CommitTransactionDatabase() => await _context.SaveChangesAsync();
    }
}
