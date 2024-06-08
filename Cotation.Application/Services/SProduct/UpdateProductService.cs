using AutoMapper;
using Cotation.Communication.DTOS.ProductDTO;
using Cotation.Communication.ModelsViews.Requests.Product;
using Cotation.Communication.ModelsViews.Responses.Product;
using Cotation.Domain.Entities;
using Cotation.Infrastructure.Repositories.RepositoryProduct;

namespace Cotation.Application.Services.SProduct {
    public class UpdateProductService(IProductRepository productRepository, IMapper mapper) {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseProduct> Execute(RequestProduct request, Guid id) {

            var product = await _productRepository.GetById(id) ?? throw new Exception("Produto não encontrado.");
            product.Name = request.Name;
            product.Description = request.Description;
            product.Category = request.Category;
            product.PriceUnit = request.PriceUnit;

            var updateProduct = await _productRepository.Update(product);

            return new ResponseProduct {
                Id = updateProduct.Id,
                Name = updateProduct.Name,
                Description = updateProduct.Description,
                Category = updateProduct.Category,
                PriceUnit = updateProduct.PriceUnit,
            };
        }
    }
}
