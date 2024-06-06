namespace Cotation.Communication.ModelsViews.Requests.Item {
    public class RequestItem {
        public Guid CompanyId { get; set; }
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
    }
}
