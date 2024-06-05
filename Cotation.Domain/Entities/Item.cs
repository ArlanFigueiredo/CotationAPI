using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cotation.Domain.Entities {
    public class Item {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        [Required][ForeignKey("Company")] public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
        [Required][ForeignKey("Product")] public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        [Required] public double Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
