using Cotation.Application.Services.SAddress;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Address {
    [Route("api/[controller]")]
    [ApiController]
    public class GetAddressByIdController(GetAddressByIdService getAddressByIdService) : ControllerBase {
        private readonly GetAddressByIdService _getAddressByIdService = getAddressByIdService;

        [HttpGet("/address/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetById([FromRoute] Guid id) {
            var service = _getAddressByIdService;

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
