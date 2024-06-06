namespace Cotation.Communication.ModelsViews.Requests.Cotations {
    public class RequestCotations {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public double Amount { get; set; }
    }
}
