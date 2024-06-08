using Cotation.Communication.ModelsViews.Responses.Item;
using Cotation.Infrastructure.Repositories.RepositoryItem;

namespace Cotation.Application.Services.SItem {
    public class GetAllItemService(IItemsRepository itemsRepository) {
        private readonly IItemsRepository _itemsRepository = itemsRepository;

        public async Task<List<ResponseItem>> Execute() {

            var item = await _itemsRepository.GetAll();

            var list = new List<ResponseItem>();

            foreach (var itemItem in item) {
                list.Add(new ResponseItem {
                    Id = itemItem.Id,
                    CompanyId = itemItem.CompanyId,
                    ProductId = itemItem.ProductId,
                    Quantity = itemItem.Quantity,
                });
            }

            return list;
        }
    }
}
