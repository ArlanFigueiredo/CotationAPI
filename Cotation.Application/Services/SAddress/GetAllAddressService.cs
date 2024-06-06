using Cotation.Domain.Entities;
using Cotation.Infrastructure.Repositories.RepositoryAddress;

namespace Cotation.Application.Services.SAddress {
    public class GetAllAddressService(IAddressRepository addressRepository) {
        private readonly IAddressRepository _addressRepository = addressRepository;
        public async Task<List<Address>> Execute() {
            return await _addressRepository.GetAll();
        }

    }
}
