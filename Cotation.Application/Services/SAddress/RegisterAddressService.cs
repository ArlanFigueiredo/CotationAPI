using AutoMapper;
using Cotation.Communication.DTOS.AddressDTO;
using Cotation.Communication.ModelsViews.Requests.Address;
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

        public async Task<Address> Execute(RequestAddress request) {
            var companyExists = await _companyRepository.GetById(request.CompanyId) ?? throw new Exception("Empresa não existe.");

            var newDTOAddress = new DTOAddress {
                CompanyId = request.CompanyId,
                ZipCode = request.ZipCode,
                Road = request.Road,
                NeighBorHood = request.NeighBorHood,
                Number = request.Number,
                City = request.City,
                State = request.State,
            };

            var newAddress = _mapper.Map<DTOAddress, Address>(newDTOAddress);

            var address = await _addressRepository.Create(newAddress);

            companyExists.AddressId = address.Id;

            await _companyRepository.Update(companyExists);

            return address;
        }
    }
}
