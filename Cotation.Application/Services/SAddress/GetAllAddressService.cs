using Cotation.Application.Interfaces.Address;
using Cotation.Communication.ModelsViews.Responses.Address;
using Cotation.Infrastructure.Repositories.RepositoryAddress;

namespace Cotation.Application.Services.SAddress {
    public class GetAllAddressService(IAddressRepository addressRepository) : IGetAllAddressService {
        private readonly IAddressRepository _addressRepository = addressRepository;
        public async Task<List<ResponseAddress>> Execute() {
            var addresss = await _addressRepository.GetAll();

            var addressList = new List<ResponseAddress>();

            foreach (var address in addresss) {
                addressList.Add(new ResponseAddress {
                    CompanyId = address.Id,
                    ZipCode = address.ZipCode,
                    Road = address.Road,
                    Number = address.Number,
                    NeighBorHood = address.NeighBorHood,
                    City = address.City,
                    State = address.State,
                });
            }
            return addressList;
        }
    }
}
