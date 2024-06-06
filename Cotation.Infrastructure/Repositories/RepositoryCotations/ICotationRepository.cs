using Cotation.Domain.Entities;

namespace Cotation.Infrastructure.Repositories.RepositoryCotations {
    public interface ICotationRepository {
        public Task<Cotations> Create(Cotations entity);
        public Task<Cotations> Update(Cotations entity);
        public Task Delete(Cotations entity);
        public Task<Cotations> GetById(Guid id);
        public Task<List<Cotations>> GetAll();
    }
}
