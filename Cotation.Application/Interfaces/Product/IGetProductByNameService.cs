using Cotation.Communication.ModelsViews.Responses.Product;

namespace Cotation.Application.Interfaces.Product {
    public interface IGetProductByNameService {
        public Task<ResponseProduct> Execute(string name);
    }
}
