using Cotation.Communication.ModelsViews.Responses.Cotations;
using Cotation.Infrastructure.Repositories.RepositoryCotations;

namespace Cotation.Application.Services.SCotations {
    public class GetCotationByIdService(ICotationRepository cotationRepository) {
        private readonly ICotationRepository _cotationRepository = cotationRepository;

        public async Task<ResponseCotations> Execute(Guid id) {
            var cotation = await _cotationRepository.GetById(id) ?? throw new Exception("Cotação não existe. Por favor, verifique.");
            return new ResponseCotations {
                CompanyId = cotation.CompanyId,
                UserId = cotation.UserId,
                Amount = cotation.Amount,
            };
        }
    }
}
