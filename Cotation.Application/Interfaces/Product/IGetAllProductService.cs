using Cotation.Communication.ModelsViews.Responses.Product;

namespace Cotation.Application.Interfaces.Product {
    public interface IGetAllProductService {
        public Task<List<ResponseProduct>> Execute();
    }
}
