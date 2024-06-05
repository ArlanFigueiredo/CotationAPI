using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cotation.Domain.Entities {
    public class Cotations {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required][ForeignKey("Company")] public Guid CompanyId { get; set; }
        public Company? Company { get; set; }    
        [Required] public double Amount { get; set; }  
        public DateTime CreatedAt { get; set; }
    }
}
