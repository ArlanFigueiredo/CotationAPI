using Cotation.Domain.Entities;

namespace Cotation.Infrastructure.Repositories.RepositoryItem {
    public interface IItemsRepository {
        public Task<Item> Create(Item entity);
        public Task<Item> Update(Item entity);
        public Task Delete(Item entity);
        public Task<Item> GetById(Guid id);
        public Task<List<Item>> GetAll();
        public Task<List<Item>> GetByCompanyId(Guid companyId);
    }
}
