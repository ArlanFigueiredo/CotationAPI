using AutoMapper;
using Cotation.Application.Interfaces.Address;
using Cotation.Communication.DTOS.AddressDTO;
using Cotation.Communication.ModelsViews.Requests.Address;
using Cotation.Communication.ModelsViews.Responses.Address;
using Cotation.Domain.Entities;
using Cotation.Infrastructure.Repositories.RepositoryAddress;

namespace Cotation.Application.Services.SAddress {
    public class UpdateAddressService(
        IAddressRepository addressRepository,
        IMapper mapper
    ) : IUpdateAddressService {
        private readonly IAddressRepository _addressRepository = addressRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseAddress> Execute(RequestAddress request, Guid id) {

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

            return new ResponseAddress {
                CompanyId = address.Id,
                ZipCode = address.ZipCode,
                Road = address.Road,
                Number = address.Number,
                NeighBorHood = address.NeighBorHood,
                City = address.City,
                State = address.State,
            };
        }
    }
}
