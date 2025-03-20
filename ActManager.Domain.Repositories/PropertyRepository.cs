using ActManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Repositories
{
    public interface IPropertyRepository : IRepository<Property>
    {
        IEnumerable<Property> GetByUserId(int userId);
    }

    public class PropertyRepository : Repository<Property>, IPropertyRepository
    {
        public PropertyRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Property> GetByUserId(int userId)
        {
            return _entities.Where(p => p.UserId == userId).ToList();
        }
    }
}
