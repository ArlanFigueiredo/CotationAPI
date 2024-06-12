using Cotation.Communication.ModelsViews.Requests.Product;
using Cotation.Communication.ModelsViews.Responses.Product;

namespace Cotation.Application.Interfaces.Product {
    public interface IRegisterProductService {
        public Task<ResponseProduct> Execute(RequestProduct request);
    }
}
