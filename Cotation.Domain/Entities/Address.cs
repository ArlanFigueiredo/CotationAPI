using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cotation.Domain.Entities {
    public class Address {

        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey("Company")] public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
        [Required] public int ZipCode { get; set; }
        [Required] public string Road { get; set; }
        [Required] public string NeighBorHood { get; set; }
        [Required] public int Number { get; set; }
        [Required] public string City { get; set; }
        [Required] public string State { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
