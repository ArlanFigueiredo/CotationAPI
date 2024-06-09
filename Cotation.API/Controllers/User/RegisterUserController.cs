using Cotation.API.Validators.User;
using Cotation.Application.Services.SUser;
using Cotation.Communication.ModelsViews.Requests.User;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.User {
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController(RegisterUserService registerUserService, ResponseErrorRegisterUser responseErrorRegisterUser) : ControllerBase {
        private readonly ResponseErrorRegisterUser _responseErrorRegisterUser = responseErrorRegisterUser;
        private readonly RegisterUserService _registerUserService = registerUserService;

        [HttpPost("/user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register([FromBody] RequestUser request) {
            var service = _registerUserService;

            try {
                var erros = await _responseErrorRegisterUser.GetErros(request);

                if (erros == null) {
                    return BadRequest(erros);
                }
                var rsult = await service.Execute(request);
                return Ok(rsult);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
