using ActManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Repositories
{
    public interface IGoalRepository : IRepository<Goal>
    {
        IEnumerable<Goal> GetByCustomerId(int customerId);
    }

    public class GoalRepository : Repository<Goal>, IGoalRepository
    {
        public GoalRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Goal> GetByCustomerId(int customerId)
        {
            return _entities.Where(g => g.Customer.ID == customerId).ToList();
        }
    }
}
