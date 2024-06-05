using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cotation.Domain.Entities {
    public class Company {
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey("Address")] public Guid? AddressId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Cnpj { get; set; }
        [Required] [Phone] public string Phone { get; set; }
        [Required] [EmailAddress] public string Email { get; set; }
        [Required] public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Address? Address { get; set; }
        public ICollection<Item>? Items { get; set; }    
        public ICollection<Cotations>? Cotations { get; set; }
    }
}
