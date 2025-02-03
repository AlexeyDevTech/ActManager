using ActManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ActManager.Domain.Repositories
{
    public class ActRepository : IRepository<Act>
    {
        ApplicationDbContext db;

        public ActRepository()
        {
          db = new ApplicationDbContext();
        }

        public void Create(Act item)
        {
            
        }

        public void Delete(Act item)
        {
            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Act> GetAll()
        {
            return db.Acts.Include(i => i.Building).Include(i => i.Files).ToList();
        }
        public IEnumerable<Act> GetAllFromBuiling(int buildingID)
        {
            return db.Acts.Include(i => i.Building).Include(i => i.Files).Where(x => x.Building.ID == buildingID).ToList();
        }

        public Act GetItem(int id)
        {
            return db.Acts.Include(i => i.Building).Include(i => i.Files).FirstOrDefault(x => x.ID == id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Act item)
        {

        }
    }
}
