using Cotation.Application.Interfaces.Product;
using Cotation.Communication.ModelsViews.Responses.Product;
using Cotation.Infrastructure.Repositories.RepositoryProduct;

namespace Cotation.Application.Services.SProduct {
    public class GetAllProductService(IProductRepository productRepository) : IGetAllProductService {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<List<ResponseProduct>> Execute() {

            var product = await _productRepository.GetAll();

            var listProduct = new List<ResponseProduct>();

            foreach (var products in product) {
                listProduct.Add(new ResponseProduct {
                    Id = products.Id,
                    Name = products.Name,
                    Description = products.Description,
                    Category = products.Category,
                    PriceUnit = products.PriceUnit,
                });
            }
            return listProduct;
        }
    }
}
