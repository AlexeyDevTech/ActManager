using ActManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Repositories
{
    public interface IBankTransactionRepository : IRepository<BankTransaction>
    {
        BankTransaction GetByTransactionId(string transactionId);
    }

    public class BankTransactionRepository : Repository<BankTransaction>, IBankTransactionRepository
    {
        public BankTransactionRepository(ApplicationDbContext context) : base(context) { }

        public BankTransaction GetByTransactionId(string transactionId)
        {
            return _entities.FirstOrDefault(bt => bt.TransactionId == transactionId);
        }
    }
}
