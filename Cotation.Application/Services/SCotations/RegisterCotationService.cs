using AutoMapper;
using Cotation.Communication.DTOS.CotationsDTO;
using Cotation.Communication.ModelsViews.Requests.Cotations;
using Cotation.Communication.ModelsViews.Responses.Cotations;
using Cotation.Domain.Entities;
using Cotation.Infrastructure.Repositories.RepositoryCompany;
using Cotation.Infrastructure.Repositories.RepositoryCotations;
using Cotation.Infrastructure.Repositories.RepositoryItem;
using Cotation.Infrastructure.Repositories.RepositoryProduct;

namespace Cotation.Application.Services.SCotations {
    public class RegisterCotationService(
        ICotationRepository cotationRepository,
        ICompanyRepository companyRepository,
        IItemsRepository itemsRepository,
        IProductRepository productRepository,
        IMapper mapper
    ) {
        private readonly ICotationRepository _cotationRepository = cotationRepository;
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IItemsRepository _itemsRepository = itemsRepository;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;
        private double Amount = 0;

        public async Task<ResponseCotations> Execute(RequestCotations cotation) {
            var company = await _companyRepository.GetById(cotation.CompanyId) ?? throw new Exception("Empresa não existe.");
            var item = await _itemsRepository.GetByCompanyId(cotation.CompanyId);

            if (item.Count == 0) {
                throw new Exception("Erro ao tentar criar uma cotação. Empresa não possui items.");
            }

            foreach (var items in item) {
                var product = await _productRepository.GetById(items.ProductId) ?? throw new Exception("Por favor confira os items, produto não identificado.");
                    Amount += (items.Quantity * product.PriceUnit);
            }

            cotation.Amount = Amount;

            var newCotation = MapToCotation(cotation);

            var createCotation = await _cotationRepository.Create(newCotation);

            return new ResponseCotations {
                CompanyId = createCotation.CompanyId,
                UserId = createCotation.UserId,
                Amount = createCotation.Amount,
            };
        }

        public Cotations MapToCotation(RequestCotations cotations) {
            return _mapper.Map<DTOCotations, Cotations>(new DTOCotations(cotations));
        }
    }
}
