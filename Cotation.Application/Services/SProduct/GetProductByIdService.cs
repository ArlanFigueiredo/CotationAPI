using Cotation.Application.Interfaces.Product;
using Cotation.Communication.ModelsViews.Responses.Product;
using Cotation.Infrastructure.Repositories.RepositoryProduct;

namespace Cotation.Application.Services.SProduct {
    public class GetProductByIdService(IProductRepository productRepository) : IGetProductByIdService {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<ResponseProduct> Execute(Guid id) {
            var product = await _productRepository.GetById(id) ?? throw new Exception("Produto não encontrado.");

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
