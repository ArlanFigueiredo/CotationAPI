using Cotation.Communication.ModelsViews.Responses.Cotations;
using Cotation.Infrastructure.Repositories.RepositoryCotations;

namespace Cotation.Application.Services.SCotations {
    public class GetAllCotationsService(ICotationRepository cotationRepository) {
        private readonly ICotationRepository _cotationRepository = cotationRepository;

        public async Task<List<ResponseCotations>> Execute() {
            var cotations = await _cotationRepository.GetAll();

            var listCotations = new List<ResponseCotations>();

            foreach (var cotation in cotations) {

                listCotations.Add(new ResponseCotations {
                    UserId = cotation.UserId,
                    CompanyId = cotation.CompanyId,
                    Amount = cotation.Amount,
                });

            }
            return listCotations;
        }
    }
}
