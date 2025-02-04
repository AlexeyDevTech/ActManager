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
            try
            {
                var res = db.Acts.FirstOrDefault(x => x.Equals(item.ID));
                if (res == null)
                {
                    db.Acts.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
            Save();
        }

        public void Delete(Act item)
        {
            try
            {
                var res = db.Acts.FirstOrDefault(x => x.Equals(item.ID));
                if (res != null)
                {
                    db.Acts.Remove(res);
                }
            }
            catch (Exception ex)
            {

            }
            Save();
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
            try
            {
                var res = db.Acts.Include(i => i.Building).FirstOrDefault(x => x.Equals(item.ID));
                if (res != null)
                {
                    res.Name = item.Name;
                    res.Building = item.Building;
                }
                Save();
            } catch (Exception ex)
            {

            }
        }
    }
}
