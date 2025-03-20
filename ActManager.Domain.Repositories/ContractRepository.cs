using ActManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Repositories
{
    public interface IContractRepository : IRepository<Contract>
    {
        IEnumerable<Contract> GetByPropertyId(int propertyId);
    }

    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        public ContractRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Contract> GetByPropertyId(int propertyId)
        {
            return _entities.Where(c => c.PropertyId == propertyId).ToList();
        }
    }
}
