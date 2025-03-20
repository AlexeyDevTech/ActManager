using ActManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Repositories
{
    public interface ICustomerAttributeRepository : IRepository<CustomerAttribute>
    {
        IEnumerable<CustomerAttribute> GetByCustomerId(int customerId);
    }

    public class CustomerAttributeRepository : Repository<CustomerAttribute>, ICustomerAttributeRepository
    {
        public CustomerAttributeRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<CustomerAttribute> GetByCustomerId(int customerId)
        {
            return _entities.Where(ca => ca.Customer.ID == customerId).ToList();
        }
    }
}
