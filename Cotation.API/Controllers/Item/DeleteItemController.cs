using Cotation.Application.Services.SItem;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Item {
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteItemController(DeleteItemService deleteItemService) : ControllerBase {
        private readonly DeleteItemService _deleteItemService = deleteItemService;

        [HttpDelete("/item/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete([FromRoute] Guid id) {
            var service = _deleteItemService;

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
