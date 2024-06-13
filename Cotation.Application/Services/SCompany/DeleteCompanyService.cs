using Cotation.Application.Interfaces.Company;
using Cotation.Infrastructure.Repositories.RepositoryCompany;

namespace Cotation.Application.Services.SCompany {
    public class DeleteCompanyService(ICompanyRepository companyRepository) : IDeleteCompanyService {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly string MessageSuccess = "Empresa deletada com sucesso.";
        public async Task<string> Execute(Guid id) {

            var companyExists = await _companyRepository.GetById(id) ?? throw new Exception("Empresa não existe");

            await _companyRepository.Delete(companyExists);

            return MessageSuccess;
        }
    }
}
