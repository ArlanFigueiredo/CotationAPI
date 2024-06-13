using Cotation.Application.Interfaces.Company;
using Cotation.Communication.ModelsViews.Responses.Company;
using Cotation.Infrastructure.Repositories.RepositoryCompany;

namespace Cotation.Application.Services.SCompany {
    public class GetAllCompanyService(ICompanyRepository companyRepository) : IGetAllCompanyService {
        private readonly ICompanyRepository _companyRepository = companyRepository;

        public async Task<List<ResponseCompany>> Execute() {
            var companys = await _companyRepository.GetAll();

            var listCompany = new List<ResponseCompany>();

            foreach (var company in companys) {

                listCompany.Add(new ResponseCompany {
                    Id = company.Id,
                    Name = company.Name,
                    Cnpj = company.Cnpj,
                    Phone = company.Phone,
                    Email = company.Email,
                });
            }
            return listCompany;
        }
    }
}
