using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cotation.Communication.ModelsViews.Responses.Cotations {
    public class ResponseCotations {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public double Amount { get; set; }
    }
}
