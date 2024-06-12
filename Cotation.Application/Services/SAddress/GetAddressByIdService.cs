using Cotation.Application.Interfaces.Address;
using Cotation.Communication.ModelsViews.Responses.Address;
using Cotation.Infrastructure.Repositories.RepositoryAddress;

namespace Cotation.Application.Services.SAddress {
    public class GetAddressByIdService(IAddressRepository addressRepository) : IGetAddressByIdService {
        private readonly IAddressRepository _addressRepository = addressRepository;
        public async Task<ResponseAddress> Execute(Guid id) {
            var address = await _addressRepository.GetById(id) ?? throw new Exception("Empresa não existe.");
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
