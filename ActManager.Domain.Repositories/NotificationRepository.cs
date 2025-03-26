using ActManager.Domain.Models;

namespace ActManager.Domain.Repositories
{
    public interface INotificationRepository : IRepository<Notification>
    {
        IEnumerable<Notification> GetByUserId(int userId);
    }

    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Notification> GetByUserId(int userId)
        {
            return _entities.Where(n => n.User.Id == userId).ToList();
        }
    }
}
