using ActManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ActManager.Domain.Repositories
{
    public interface IActRepository : IRepository<Act>
    {
        IEnumerable<Act> GetByBuildingId(int buildingId);
    }

    public class ActRepository : Repository<Act>, IActRepository
    {
        public ActRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Act> GetByBuildingId(int buildingId)
        {
            return _entities.Where(a => a.Building.ID == buildingId).ToList();
        }
    }
}
