using Cotation.Domain.Entities;
using Cotation.Infrastructure.Repositories.RepositoryAddress;

namespace Cotation.Application.Services.SAddress {
    public class GetAddressByIdService(IAddressRepository addressRepository) {
        private readonly IAddressRepository _addressRepository = addressRepository;
        public async Task<Address> Execute(Guid id) {
            var address = await _addressRepository.GetById(id) ?? throw new Exception("Empresa não existe.");
            return address;
        }
    }
}
