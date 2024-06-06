namespace Cotation.Communication.DTOS.CotationsDTO {
    public class DTOCotations {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
