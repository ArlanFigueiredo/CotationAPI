using Cotation.Communication.ModelsViews.Requests.Cotations;
using Cotation.Communication.ModelsViews.Responses.Cotations;
using Cotation.Infrastructure.Repositories.RepositoryCompany;
using Cotation.Infrastructure.Repositories.RepositoryCotations;
using Cotation.Infrastructure.Repositories.RepositoryItem;
using Cotation.Infrastructure.Repositories.RepositoryProduct;

namespace Cotation.Application.Services.SCotations {
    public class UpdateCotationService(
        ICotationRepository cotationRepository,
        ICompanyRepository companyRepository,
        IItemsRepository itemsRepository,
        IProductRepository productRepository
    ) {
        private readonly ICotationRepository _cotationRepository = cotationRepository;
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IItemsRepository _itemsRepository = itemsRepository;
        private readonly IProductRepository _productRepository = productRepository;
        private double Amount = 0;

        public async Task<ResponseCotations> Execute(RequestCotations cotations, Guid id) {
            var cotation = await _cotationRepository.GetById(id) ?? throw new Exception("Cotação não existe.");
            _ = await _companyRepository.GetById(cotations.CompanyId) ?? throw new Exception("Empresa não encontrada.");
            var item = await _itemsRepository.GetByCompanyId(cotations.CompanyId);

            if (item.Count == 0) {
                throw new Exception("Erro ao tentar criar uma cotação. Empresa não possui items.");
            }

            foreach (var items in item) {
                var product = await _productRepository.GetById(items.ProductId) ?? throw new Exception("Por favor, verifique se o produto ou serviço existe.");
                Amount += (items.Quantity * product.PriceUnit);
            }
            cotation.Amount = Amount;

            var updateCotation = await _cotationRepository.Update(cotation);

            return new ResponseCotations {
                CompanyId = cotations.CompanyId,
                UserId = cotations.UserId,
                Amount = Amount,
            };
        }
    }
}
