using Cotation.Application.Utilities.User;
using Cotation.Communication.ModelsViews.Requests.User;
using Cotation.Infrastructure.Repositories.RepositoryUser;

namespace Cotation.Application.Services.SUser {
    public class AuthenticateUser(
        IUserRepository userRepository,
        VerifyHashPassword verifyHashPassword,
        GenerateTokenJWT generateTokenJWT
    ) {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly VerifyHashPassword _verifyHashPassword = verifyHashPassword;
        private readonly GenerateTokenJWT _generateTokenJWT = generateTokenJWT;

        public async Task<string> Execute(RequestLoginUser login) {
            var user = await _userRepository.GetByEmail(login.Email) ?? throw new Exception("Credenciais invalida. Por favor, verifique e tente novamente.");

            var authenticated = _verifyHashPassword.VerifyPasswordHash(user.Password, user.Salt, login.Password);
                if (authenticated == false) {
                throw new Exception("Credenciais invalidas. Por favor, verifique e tente novamente.");
            }

            var token = _generateTokenJWT.GenerateJwtToken(user.Id.ToString(), user.Email, user.Role);
            return token;
        }
    }
}
