using Cotation.Infrastructure.Repositories.RepositoryAddress;

namespace Cotation.Application.Services.SAddress {
    public class DeleteAddressService(IAddressRepository addressRepository) {
        private readonly IAddressRepository _addressRepository = addressRepository;
        private readonly string MessageSuccess = "Endereço deletado com sucesso";
        public async Task<string> Execute(Guid id) {
            var address = await _addressRepository.GetById(id) ?? throw new Exception("Endereço não existe");
            await _addressRepository.Delete(address);
            return MessageSuccess;
        }
    }
}
