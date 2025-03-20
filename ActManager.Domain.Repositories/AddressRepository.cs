using ActManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        IEnumerable<Address> GetByStreet(string street);
    }

    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Address> GetByStreet(string street)
        {
            return _entities.Where(a => a.Street == street).ToList();
        }
    }
}
