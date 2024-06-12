using Cotation.Communication.ModelsViews.Responses.Address;

namespace Cotation.Application.Interfaces.Address {
    public interface IGetAllAddressService {
        public Task<List<ResponseAddress>> Execute();
    }
}
