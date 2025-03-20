using ActManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ActManager.Domain.Repositories
{
    public interface IBuildingRepository : IRepository<Building>
    {
        IEnumerable<Building> GetByAddressId(int addressId);
    }

    public class BuildingRepository : Repository<Building>, IBuildingRepository
    {
        public BuildingRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Building> GetByAddressId(int addressId)
        {
            return _entities.Where(b => b.AddressInst.ID == addressId).ToList();
        }
    }
}
