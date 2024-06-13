namespace Cotation.Application.Interfaces.Address {
    public interface IDeleteAddressService {
        public Task<string> Execute(Guid id);
    }
}
