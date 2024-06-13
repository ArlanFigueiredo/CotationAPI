using Cotation.Communication.ModelsViews.Requests.User;

namespace Cotation.Application.Interfaces.User
{
    public interface IAuthenticateUserService
    {
        public Task<string> Execute(RequestLoginUser request);
    }
}
