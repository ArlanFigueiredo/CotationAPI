using Cotation.Application.Services.SItem;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Item {
    [Route("api/[controller]")]
    [ApiController]
    public class GetItemByIdController(GetItemByIdService getItemByIdService) : ControllerBase {
        private readonly GetItemByIdService _getItemByIdService = getItemByIdService;

        [HttpGet("/item/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetById([FromRoute] Guid id) {
            var service = _getItemByIdService;

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
