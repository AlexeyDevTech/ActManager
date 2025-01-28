using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Repositories
{
    public abstract class BaseRepository<T>
    {
        public abstract List<T> GetAll();
    }
}
