using Cotation.Domain.Entities;
using Cotation.Infrastructure.Repositories.RepositoryCompany;

namespace Cotation.Application.Services.SCompany {
    public class GetAllCompanyService(ICompanyRepository companyRepository) {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        public async Task<List<Company>> Execute() {
            return await _companyRepository.GetAll();
        }
    }
}
