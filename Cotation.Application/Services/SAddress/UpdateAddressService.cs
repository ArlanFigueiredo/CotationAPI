using AutoMapper;
using Cotation.Communication.DTOS.AddressDTO;
using Cotation.Communication.ModelsViews.Requests.Address;
using Cotation.Domain.Entities;
using Cotation.Infrastructure.Repositories.RepositoryAddress;

namespace Cotation.Application.Services.SAddress {
    public class UpdateAddressService(
        IAddressRepository addressRepository,
        IMapper mapper
    ) {
        private readonly IAddressRepository _addressRepository = addressRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Address> Execute(RequestAddress request, Guid id) {

            _ = await _addressRepository.GetById(id) ?? throw new Exception("Endereço não encontrado.");

            var newDTOAddress = new DTOAddress {
                Id = id,
                CompanyId = request.CompanyId,
                ZipCode = request.ZipCode,
                Road = request.Road,
                NeighBorHood = request.NeighBorHood,
                Number = request.Number,
                City = request.City,
                State = request.State,
            };

            var newAddress = _mapper.Map<DTOAddress, Address>(newDTOAddress);

            var address = await _addressRepository.Update(newAddress);

            return address;
        }
    }
}
