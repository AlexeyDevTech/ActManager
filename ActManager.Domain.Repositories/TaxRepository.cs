using ActManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Repositories
{
    public interface ITaxRepository : IRepository<Tax>
    {
        IEnumerable<Tax> GetByUserId(int userId);
    }

    public class TaxRepository : Repository<Tax>, ITaxRepository
    {
        public TaxRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Tax> GetByUserId(int userId)
        {
            return _entities.Where(t => t.UserId == userId).ToList();
        }
    }
}
