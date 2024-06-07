using AutoMapper;
using Cotation.Communication.DTOS.CompanyDTO;
using Cotation.Communication.ModelsViews.Requests.Company;
using Cotation.Communication.ModelsViews.Responses.Company;
using Cotation.Domain.Entities;
using Cotation.Infrastructure.Repositories.RepositoryCompany;

namespace Cotation.Application.Services.SCompany {
    public class UpdateCompanyService(ICompanyRepository companyRepository, IMapper mapper) {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseCompany> Execute(RequestCompany request, Guid id) {
            _ = await _companyRepository.GetById(id) ?? throw new Exception("Empresa não existe.");

            var newDTOCompany = new DTOCompany() {
                Id = id,
                Name = request.Name,
                Cnpj = request.Cnpj,
                Phone = request.Phone,
                Email = request.Email,
            };

            var newCompany = _mapper.Map<DTOCompany, Company>(newDTOCompany);

            var resultCompany = await _companyRepository.Update(newCompany);

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
