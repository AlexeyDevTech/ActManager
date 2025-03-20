using ActManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByFullName(string firstName, string secondName);
    }

    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context) { }

        public Customer GetByFullName(string firstName, string secondName)
        {
            return _entities.FirstOrDefault(c => c.FirstName == firstName && c.SecondName == secondName);
        }
    }
}
