using Cotation.Infrastructure.Repositories.RepositoryItem;

namespace Cotation.Application.Services.SItem {
    public class DeleteItemService(IItemsRepository itemsRepository) {
        private readonly IItemsRepository _itemsRepository = itemsRepository;
        private readonly string MessageSuccess = "Item deletado com sucesso.";
        public async Task<string> Execute(Guid id) {
            var item = await _itemsRepository.GetById(id) ?? throw new Exception("Item não encontrado.");
            await _itemsRepository.Delete(item);
            return MessageSuccess;
        }
    }
}
