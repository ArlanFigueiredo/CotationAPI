using Cotation.Application.Interfaces.User;
using Cotation.Communication.ModelsViews.Requests.User;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateUserController(
        IAuthenticateUserService authenticateUserService
        //SettingsEmailService settingsEmailService,
        //SendTestEmail sendTestEmail

    ) : ControllerBase {
        private readonly IAuthenticateUserService _authenticateUserService = authenticateUserService;
        //private readonly SettingsEmailService _settingsEmailService = settingsEmailService;
        //private readonly SendTestEmail _sendTestEmail = sendTestEmail;

        [HttpPost("/user/authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Authenticate([FromBody] RequestLoginUser request) {
            var service = _authenticateUserService;

            try {
                //var resultSend = _sendTestEmail.SenderTestEmail("Você fez login", "Sua conta está autenticada!", "estudosarlan@gmail.com");
                //await _settingsEmailService.OnConfigurateSendEmailService(resultSend);
                
                var result = await service.Execute(request);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
