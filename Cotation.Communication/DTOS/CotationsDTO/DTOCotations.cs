using Cotation.Communication.ModelsViews.Requests.Cotations;

namespace Cotation.Communication.DTOS.CotationsDTO {
    public class DTOCotations {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }

        public DTOCotations(RequestCotations cotations) { 
            UserId = cotations.UserId;
            CompanyId = cotations.CompanyId;
            Amount = cotations.Amount;
        }

        public DTOCotations() { }   
    }
}
