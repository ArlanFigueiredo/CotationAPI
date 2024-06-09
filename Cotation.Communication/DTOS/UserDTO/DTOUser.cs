using Cotation.Communication.ModelsViews.Requests.User;

namespace Cotation.Communication.DTOS.UserDTO {
    public class DTOUser {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }

        public DTOUser(RequestUser user) {
            Name = user.Name; 
            Email = user.Email; 
            Password = user.Password; 
            Salt = user.Salt; 
            Role = user.Role;
        }

        public DTOUser() { }
    }
}
