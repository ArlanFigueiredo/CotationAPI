using Cotation.Application.Services.SAddress;
using Microsoft.AspNetCore.Mvc;
namespace Cotation.API.Controllers.Address {
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteAddressController(DeleteAddressService deleteAddressService) : ControllerBase {
        private readonly DeleteAddressService _deleteAddressService = deleteAddressService;

        [HttpDelete("/address/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete([FromRoute] Guid id) {
            var service = _deleteAddressService;

            try {
                var result = await service.Execute(id);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
