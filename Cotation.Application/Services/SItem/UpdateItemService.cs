using Cotation.Communication.ModelsViews.Requests.Item;
using Cotation.Communication.ModelsViews.Responses.Item;
using Cotation.Infrastructure.Repositories.RepositoryCompany;
using Cotation.Infrastructure.Repositories.RepositoryItem;
using Cotation.Infrastructure.Repositories.RepositoryProduct;

namespace Cotation.Application.Services.SItem {
    public class UpdateItemService(
        IItemsRepository itemsRepository,
        IProductRepository productRepository,
        ICompanyRepository companyRepository
    ) {
        private readonly IItemsRepository _itemsRepository = itemsRepository;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ICompanyRepository _companyRepository = companyRepository;

        public async Task<ResponseItem> Execute(RequestItem request, Guid id) {

            var company = await _companyRepository.GetById(request.CompanyId) ?? throw new Exception("Empresa não existe.");
            var product = await _productRepository.GetById(request.ProductId) ?? throw new Exception("Produto não existe.");

            var item = await _itemsRepository.GetById(id) ?? throw new Exception("Item não existe.");
            item.Quantity = request.Quantity;

            return new ResponseItem {
                Id = item.Id,
                CompanyId = item.CompanyId,
                ProductId = item.ProductId,
                Quantity = request.Quantity,
            };
        }
    }
}
