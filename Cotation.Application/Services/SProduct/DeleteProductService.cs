using Cotation.Infrastructure.Repositories.RepositoryProduct;

namespace Cotation.Application.Services.SProduct {
    public class DeleteProductService(IProductRepository productRepository) {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly string MessageSuccess = "Produto deletado com sucesso.";
        public async Task<string> Execute(Guid id) {
            var product = await _productRepository.GetById(id) ?? throw new Exception("Produto não encontrado");
            await _productRepository.Delete(product);
            return MessageSuccess;
        }
    }
}
