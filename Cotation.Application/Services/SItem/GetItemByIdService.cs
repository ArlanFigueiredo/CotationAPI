using Cotation.Communication.ModelsViews.Responses.Item;
using Cotation.Infrastructure.Repositories.RepositoryItem;

namespace Cotation.Application.Services.SItem {
    public class GetItemByIdService(IItemsRepository itemsRepository) {
        private readonly IItemsRepository _itemsRepository = itemsRepository;

        public async Task<ResponseItem> Execute(Guid id) {
            var item = await _itemsRepository.GetById(id) ?? throw new Exception("Item não existe.");

            return new ResponseItem {
                Id = item.Id,
                CompanyId = item.CompanyId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
            };
        }
    }
}
