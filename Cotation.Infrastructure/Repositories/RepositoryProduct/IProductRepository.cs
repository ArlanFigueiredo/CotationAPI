using Cotation.Communication.ModelsViews.Requests.Product;
using Cotation.Domain.Entities;

namespace Cotation.Infrastructure.Repositories.RepositoryProduct {
    public interface IProductRepository {
        public Task<Product> Create(Product entity);

        public Task<Product> Update(Product entity);    
        public Task Delete(Product entity);
        public Task<Product> GetById(Guid id);
        public Task<Product> GetByName(string name);
        public Task<List<Product>> GetAll();
        public Task<List<Product>> GetProductAsync(RequestListProduct request);
    }
}
