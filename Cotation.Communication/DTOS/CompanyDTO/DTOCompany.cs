using Cotation.Communication.ModelsViews.Responses.Company;
using Cotation.Domain.Entities;

namespace Cotation.Communication.DTOS.CompanyDTO {
    public class DTOCompany {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? AddressId { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DTOCompany(ResponseCompany company) {
            Id = company.Id;
            Name = company.Name;
            Cnpj = company.Cnpj;
            Phone = company.Phone;
            Email = company.Email;
        }

        public DTOCompany() { }

    }
}
