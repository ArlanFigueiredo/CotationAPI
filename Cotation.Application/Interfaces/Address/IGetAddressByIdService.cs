using Cotation.Communication.ModelsViews.Responses.Address;

namespace Cotation.Application.Interfaces.Address {
    public interface IGetAddressByIdService {
        public Task<ResponseAddress> Execute(Guid id);
    }
}
