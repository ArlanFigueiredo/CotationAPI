using System.ComponentModel.DataAnnotations;

namespace Cotation.Domain.Entities {
    public class User {

        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        [Required] public string Name { get; set; }
        [Required] [EmailAddress] public string Email { get; set;}
        [Required] public string Password { get; set; }
        [Required] public string Salt { get; set; }
        public string Role { get; set; } = "Admin";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Cotations>? Cotations { get; set; }
    }
}
