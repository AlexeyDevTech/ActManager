using ActManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Repositories
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        IEnumerable<Expense> GetByPropertyId(int propertyId);
    }

    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Expense> GetByPropertyId(int propertyId)
        {
            return _entities.Where(e => e.PropertyId == propertyId).ToList();
        }
    }
}
