using Challenger.Models.Models.Interfaces;
using Challenger.Repository;

namespace Challenger.Services.Services
{
    public class TransactionDatabaseService : ITransactionDatabaseService
    {
        private readonly HMVContext _context;

        public TransactionDatabaseService(HMVContext context)
        {
            _context = context;
        }

        public async void CommitTransactionDatabase() => await _context.SaveChangesAsync();

        public void RollbackTransactionDatabase() => _context.Database.RollbackTransaction();
    }
}
