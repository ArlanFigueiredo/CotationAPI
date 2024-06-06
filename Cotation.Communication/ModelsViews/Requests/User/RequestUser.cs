using System.ComponentModel.DataAnnotations;

namespace Cotation.Communication.ModelsViews.Requests.User {
    public class RequestUser {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }

    }
}
