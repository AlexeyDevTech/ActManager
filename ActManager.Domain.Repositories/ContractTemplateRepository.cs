using ActManager.Domain.Models;

namespace ActManager.Domain.Repositories
{
    public interface IContractTemplateRepository : IRepository<ContractTemplate>
    {
        IEnumerable<ContractTemplate> GetByUserId(int userId);
    }

    public class ContractTemplateRepository : Repository<ContractTemplate>, IContractTemplateRepository
    {
        public ContractTemplateRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<ContractTemplate> GetByUserId(int userId)
        {
            return _entities.Where(ct => ct.UserId == userId).ToList();
        }
    }
}
