using AutoMapper;
using Cotation.Communication.DTOS.ItemDTO;
using Cotation.Communication.ModelsViews.Requests.Item;
using Cotation.Communication.ModelsViews.Responses.Item;
using Cotation.Domain.Entities;
using Cotation.Infrastructure.Repositories.RepositoryCompany;
using Cotation.Infrastructure.Repositories.RepositoryItem;
using Cotation.Infrastructure.Repositories.RepositoryProduct;

namespace Cotation.Application.Services.SItem {
    public class RegisterItemService(
        IItemsRepository itemsRepository,
        IProductRepository productRepository,
        ICompanyRepository companyRepository,
        IMapper mapper
    ) {
        private readonly IItemsRepository _itemsRepository = itemsRepository;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper;

        public async Task<ResponseItem> Execute(RequestItem request) {
            var company = await _companyRepository.GetById(request.CompanyId) ?? throw new Exception("Empresa não encontrada.");
            var product = await _productRepository.GetById(request.ProductId) ?? throw new Exception("Produto não encontrado.");

            var companyItem = await _itemsRepository.GetByCompanyId(request.CompanyId);

            foreach (var items in companyItem) {
                if (items.CompanyId == request.CompanyId && items.ProductId == request.ProductId) {
                    throw new Exception("Item já existe. Por favor, verifique.");
                }
            }
            var newItem = MapToIten(request);
            var item = await _itemsRepository.Create(newItem);

            return new ResponseItem {
                Id = item.Id,
                CompanyId = item.CompanyId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
            };
        }

        public Item MapToIten(RequestItem request) {
            return _mapper.Map<DTOItem, Item>(new DTOItem(request));
        }
    }
}
