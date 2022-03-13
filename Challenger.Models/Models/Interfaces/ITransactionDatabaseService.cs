using System;
using System.Collections.Generic;
using System.Text;

namespace Challenger.Models.Models.Interfaces
{
    public interface ITransactionDatabaseService
    {
        void RollbackTransactionDatabase();
        void CommitTransactionDatabase();
    }
}
