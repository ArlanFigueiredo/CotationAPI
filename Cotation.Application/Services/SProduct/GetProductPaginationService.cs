using Cotation.Communication.ModelsViews.Requests.Product;
using Cotation.Communication.ModelsViews.Responses.Product;
using Cotation.Infrastructure.Repositories.RepositoryProduct;

namespace Cotation.Application.Services.SProduct {
    public class GetProductPaginationService(IProductRepository productRepository) {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<List<ResponseProduct>> Execute(RequestListProduct request) {
            var products = await _productRepository.GetProductAsync(request);

            var listProducts = new List<ResponseProduct>();

            foreach (var product in products) {
                listProducts.Add(new ResponseProduct {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = product.Category,
                    PriceUnit = product.PriceUnit,
                });
            }
            return listProducts;
        }
    }
}
