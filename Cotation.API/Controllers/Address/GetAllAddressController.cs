using Cotation.Application.Services.SAddress;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Address {
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllAddressController(GetAllAddressService getAllAddressService) : ControllerBase {
        private readonly GetAllAddressService _getAllAddressService = getAllAddressService;

        [HttpGet("/address")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAll() {
            var service = _getAllAddressService;

            try {
                var result = await service.Execute();
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
