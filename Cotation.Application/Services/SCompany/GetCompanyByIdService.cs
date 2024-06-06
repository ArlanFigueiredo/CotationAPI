using Cotation.Domain.Entities;
using Cotation.Infrastructure.Repositories.RepositoryCompany;

namespace Cotation.Application.Services.SCompany {
    public class GetCompanyByIdService(ICompanyRepository companyRepository) {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        public async Task<Company> Execute(Guid id) {
            var companyExists = await _companyRepository.GetById(id) ?? throw new Exception("Empresa não existe.");
            return companyExists;
        }
    }
}
