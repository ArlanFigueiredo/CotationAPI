using Cotation.Infrastructure.Repositories.RepositoryCotations;

namespace Cotation.Application.Services.SCotations {
    public class DeleteCotationSerivce(ICotationRepository cotationRepository) {
        private readonly ICotationRepository _cotationRepository = cotationRepository;
        private readonly string MessageSuccess = "Cotação deletado com sucesso.";
        public async Task<string> Execute(Guid id) {
            var cotation = await _cotationRepository.GetById(id) ?? throw new Exception("Cotação não encontrada. Por favor, verifique.");
            await _cotationRepository.Delete(cotation);
            return MessageSuccess;
        }
    }
}
