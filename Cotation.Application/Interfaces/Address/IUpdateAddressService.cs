using Cotation.Communication.ModelsViews.Requests.Address;
using Cotation.Communication.ModelsViews.Responses.Address;

namespace Cotation.Application.Interfaces.Address {
    public interface IUpdateAddressService {
        public Task<ResponseAddress> Execute(RequestAddress request, Guid id);
    }
}
