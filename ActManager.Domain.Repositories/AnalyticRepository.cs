using ActManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Repositories
{
    public interface IAnalyticRepository : IRepository<Analytic>
    {
        IEnumerable<Analytic> GetByPropertyId(int propertyId);
    }

    public class AnalyticRepository : Repository<Analytic>, IAnalyticRepository
    {
        public AnalyticRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Analytic> GetByPropertyId(int propertyId)
        {
            return _entities.Where(a => a.PropertyId == propertyId).ToList();
        }
    }
}
