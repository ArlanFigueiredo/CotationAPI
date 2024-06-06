namespace Cotation.Communication.DTOS.CompanyDTO {
    public class DTOCompany {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? AddressId { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
