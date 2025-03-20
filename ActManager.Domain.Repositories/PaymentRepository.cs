using ActManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Repositories
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        IEnumerable<Payment> GetByContractId(int contractId);
    }

    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Payment> GetByContractId(int contractId)
        {
            return _entities.Where(p => p.ContractId == contractId).ToList();
        }
    }
}
