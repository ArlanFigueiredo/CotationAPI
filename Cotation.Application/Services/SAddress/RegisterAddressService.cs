using AutoMapper;
using Cotation.Communication.DTOS.AddressDTO;
using Cotation.Communication.ModelsViews.Requests.Address;
using Cotation.Communication.ModelsViews.Responses.Address;
using Cotation.Domain.Entities;
using Cotation.Infrastructure.Repositories.RepositoryAddress;
using Cotation.Infrastructure.Repositories.RepositoryCompany;

namespace Cotation.Application.Services.SAddress {
    public class RegisterAddressService(
        IAddressRepository addressRepository,
        ICompanyRepository companyRepository,
        IMapper mapper
    ) {
        private readonly IAddressRepository _addressRepository = addressRepository;
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseAddress> Execute(RequestAddress request) {

            var company = await _companyRepository.GetById(request.CompanyId) ?? throw new Exception("Empresa não existe.");

            var addressExsists = await _addressRepository.GetAddressByCompany(request.CompanyId);
            _ = (addressExsists != null) ? throw new Exception("Essa empresa já possui um endereço.") : addressExsists;

            var newDTOAddress = new DTOAddress(request);

            var newAddress = _mapper.Map<DTOAddress, Address>(newDTOAddress);

            var address = await _addressRepository.Create(newAddress);

            company.AddressId = address.Id;

            await _companyRepository.Update(company);

            return new ResponseAddress {
                Id = address.Id,
                CompanyId = address.CompanyId,
                ZipCode = address.ZipCode,
                Road = address.Road,
                NeighBorHood = address.NeighBorHood,
                Number = address.Number,
                City = address.City,
                State = address.State,
            };
        }
    }
}
