using Cotation.Application.Interfaces.Product;
using Cotation.Communication.ModelsViews.Responses.Product;
using Cotation.Infrastructure.Repositories.RepositoryProduct;

namespace Cotation.Application.Services.SProduct {
    public class GetProductByNameService(IProductRepository productRepository) : IGetProductByNameService {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<ResponseProduct> Execute(string name) {
            var product = await _productRepository.GetByName(name) ?? throw new Exception("Produto não existe.");

            return new ResponseProduct {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                PriceUnit = product.PriceUnit,
            };
        }
    }
}
