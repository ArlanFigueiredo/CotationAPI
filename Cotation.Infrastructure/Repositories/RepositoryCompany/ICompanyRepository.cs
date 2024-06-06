using Cotation.Communication.DTOS.CompanyDTO;
using Cotation.Domain.Entities;

namespace Cotation.Infrastructure.Repositories.RepositoryCompany {
    public interface ICompanyRepository {
        
        public Task<Company> Create(Company entity);
        public Task Update(Company entity);
        public Task Delete(Company entity);
        public Task<Company> GetById(Guid id);
        public Task<Company> GetByCompany(string name);
        public Task<List<Company>> GetAll();
    }
}
