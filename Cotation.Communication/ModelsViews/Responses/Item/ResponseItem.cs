namespace Cotation.Communication.ModelsViews.Responses.Item {
    public class ResponseItem {
        public Guid Id { get; set; }  
        public Guid CompanyId { get; set; }
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
    }
}
