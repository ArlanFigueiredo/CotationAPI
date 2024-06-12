using Cotation.Communication.ModelsViews.Responses.Product;

namespace Cotation.Application.Interfaces.Product {
    public interface IGetProductByIdService {
        public Task<ResponseProduct> Execute(Guid id);
    }
}
