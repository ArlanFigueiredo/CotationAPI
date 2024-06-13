using AutoMapper;
using Cotation.Application.Interfaces.Company;
using Cotation.Communication.DTOS.CompanyDTO;
using Cotation.Communication.ModelsViews.Requests.Company;
using Cotation.Communication.ModelsViews.Responses.Company;
using Cotation.Domain.Entities;
using Cotation.Infrastructure.Repositories.RepositoryCompany;

namespace Cotation.Application.Services.SCompany {
    public class RegisterCompanyService(ICompanyRepository companyRepository, IMapper mapper) : IRegisterCompanyService {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseCompany> Execute(RequestCompany request) {
            var newDTOCompany = new DTOCompany() {
                Name = request.Name,
                Cnpj = request.Cnpj,
                Phone = request.Phone,
                Email = request.Email,
            };

            var newCompany = _mapper.Map<DTOCompany, Company>(newDTOCompany);

            var resultCompany = await _companyRepository.Create(newCompany);

            return new ResponseCompany {
                Id = resultCompany.Id,
                Name = resultCompany.Name,
                Phone = resultCompany.Phone,
                Email = resultCompany.Email,
                Cnpj = resultCompany.Cnpj,
            };
        }
    }
}
