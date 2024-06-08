using Cotation.Communication.ModelsViews.Responses.Item;
using Cotation.Infrastructure.Repositories.RepositoryItem;

namespace Cotation.Application.Services.SItem {
    public class GetItemsByCompanyServices(IItemsRepository itemsRepository) {
        private readonly IItemsRepository _itemsRepository = itemsRepository;

        public async Task<List<ResponseItem>> Execute(Guid companyId) {
            var company = await _itemsRepository.GetById(companyId) ?? throw new Exception("Empresa não existe.");

            var items = await _itemsRepository.GetByCompanyId(companyId) ?? throw new Exception("Empresa não possui items.");

            var listItems = new List<ResponseItem>();

            foreach (var item in listItems) {
                listItems.Add(new ResponseItem {
                    Id = item.Id,
                    CompanyId = companyId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                });
            }
            return listItems;
        }
    }
}
