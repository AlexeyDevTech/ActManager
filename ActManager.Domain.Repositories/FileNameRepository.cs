using ActManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Repositories
{
    public interface IFileNameRepository : IRepository<FileName>
    {
        IEnumerable<FileName> GetByActId(int actId);
    }

    public class FileNameRepository : Repository<FileName>, IFileNameRepository
    {
        public FileNameRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<FileName> GetByActId(int actId)
        {
            return _entities.Where(f => f.Act.ID == actId).ToList();
        }
    }
}
