namespace ActManager.Domain.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Save();
    }
}
