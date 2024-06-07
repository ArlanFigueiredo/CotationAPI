using Cotation.Application.Services.SAddress;
using Cotation.Communication.ModelsViews.Requests.Address;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Address {
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterAddressController(RegisterAddressService registerAddressService) : ControllerBase {
        private readonly RegisterAddressService _registerAddressService = registerAddressService;

        [HttpPost("/address")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register([FromBody] RequestAddress request) {
            var service = _registerAddressService;

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
