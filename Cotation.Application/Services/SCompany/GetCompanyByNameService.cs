using Cotation.Application.Interfaces.Company;
using Cotation.Communication.ModelsViews.Responses.Company;
using Cotation.Domain.Entities;
using Cotation.Infrastructure.Repositories.RepositoryCompany;

namespace Cotation.Application.Services.SCompany {
    public class GetCompanyByNameService(ICompanyRepository companyRepository) : IGetCompanyByNameService {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        public async Task<Company> Execute(string company) {
            var companyExists = await _companyRepository.GetByCompany(company) ?? throw new Exception("Empresa não existe.");
            return companyExists;
        }

        Task<ResponseCompany> IGetCompanyByNameService.Execute(string name) {
            throw new NotImplementedException();
        }
    }
}
