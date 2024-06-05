using System.ComponentModel.DataAnnotations;

namespace Cotation.Domain.Entities {
    public class Product {

        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public string Category { get; set; }
        [Required] public double PriceUnit { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Item>? Items { get; set; }    
      
    }
}
