using Cotation.Application.Services.SUser;
using Cotation.Communication.ModelsViews.Requests.User;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.User {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateUserController(AuthenticateUserService authenticateUserService) : ControllerBase {
        private readonly AuthenticateUserService _authenticateUserService = authenticateUserService;

        [HttpPost("/user/authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Authenticate([FromBody] RequestLoginUser request) {
            var service = _authenticateUserService;

            try {
                var result = await service.Execute(request);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
