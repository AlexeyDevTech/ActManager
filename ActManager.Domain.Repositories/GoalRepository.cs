using ActManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Repositories
{
    public class GoalRepository : IRepository<Goal>
    {
        private ApplicationDbContext db;

        public GoalRepository()
        {
          db = new ApplicationDbContext();
        }

        public void Create(Goal item)
        {
            db.Add(item);
            Save();
        }

        public void Delete(Goal item)
        {
            var res = db.Goals.First(x => x.ID == item.ID);
            db.Goals.Remove(res);
            Save();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Goal> GetAll()
        {
            return db.Goals.ToList();
        }

        public Goal GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Goal item)
        {
            throw new NotImplementedException();
        }
    }
}
