using Cotation.Application.Services.SAddress;
using Cotation.Communication.ModelsViews.Requests.Address;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Address {
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateAddressController(UpdateAddressService updateAddressService) : ControllerBase {
        private readonly UpdateAddressService _updateAddressService = updateAddressService;

        [HttpPut("/address/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update([FromBody] RequestAddress request, [FromRoute] Guid id) {
            var service = _updateAddressService;

            try {
                var result = await service.Execute(request, id);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
