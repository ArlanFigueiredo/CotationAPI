namespace Cotation.Communication.DTOS.ItemDTO {
    public class DTOItem {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
