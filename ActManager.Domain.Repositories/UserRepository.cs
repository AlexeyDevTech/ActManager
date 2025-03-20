using ActManager.Domain.Models;

namespace ActManager.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public User GetByUsername(string username)
        {
            return _entities.FirstOrDefault(u => u.Username == username);
        }
    }
}
