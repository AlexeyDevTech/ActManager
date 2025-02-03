using ActManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ActManager.Domain.Repositories
{
    public class BuildingsRepository : IRepository<Building>
    {
        ApplicationDbContext _db;
        public BuildingsRepository()
        {
          _db = new ApplicationDbContext();
        }
        public void Create(Building item)
        {
            _db.Add(item.AddressInst);
            _db.Add(item);
            Save();
        }

        public void Delete(Building item)
        {
            var local = GetItem(item.ID);
            if (local != null)
            {
                _db.Buildings.Remove(local);
                Save();
            }
        }

        public IEnumerable<Building> GetAll()
        {
            return _db.Buildings.Include(i => i.AddressInst).ToList();
        }

        public Building GetItem(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var item = _db.Buildings.Include(i => i.AddressInst).FirstOrDefault(x => x.Equals(id));
            if (item != null)
                return item;
            else throw new NullReferenceException();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Building item)
        {
            try
            {
                var local = GetItem(item.ID);
                if(local != null)
                {
                    local.Name = item.Name;
                    local.AddressInst = item.AddressInst;
                }
                if(local != null)
                    _db.Update(local);
                Save();
            }
            catch 
            { 

            }

        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
