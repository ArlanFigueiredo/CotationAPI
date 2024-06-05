using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cotation.Domain.Entities {
    public class Cotations {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        [Required] [ForeignKey("User")] public Guid UserId { get; set; }
        public User? User { get; set; }
        [Required][ForeignKey("Company")] public Guid CompanyId { get; set; }
        public Company? Company { get; set; }    
        [Required] public double Amount { get; set; }  
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
