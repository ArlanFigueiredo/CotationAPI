using AutoMapper;
using Cotation.Application.Interfaces.Product;
using Cotation.Communication.DTOS.ProductDTO;
using Cotation.Communication.ModelsViews.Requests.Product;
using Cotation.Communication.ModelsViews.Responses.Product;
using Cotation.Domain.Entities;
using Cotation.Infrastructure.Repositories.RepositoryProduct;

namespace Cotation.Application.Services.SProduct {
    public class RegisterProductService(IProductRepository productRepository, IMapper mapper) : IRegisterProductService {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseProduct> Execute(RequestProduct request) {

            var newProduct = MapToProduct(request);

            var product = await _productRepository.Create(newProduct);

            return new ResponseProduct {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Description = product.Description,
                PriceUnit = product.PriceUnit,
            };
        }

        public Product MapToProduct(RequestProduct request) {
            return _mapper.Map<DTOProduct, Product>(new DTOProduct(request));
        }
    }
}
