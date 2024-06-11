using Cotation.Application.Services.SItem;
using Cotation.Communication.ModelsViews.Requests.Item;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Item {
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateItemController(UpdateItemService updateItemService) : ControllerBase {
        private readonly UpdateItemService _updateItemService = updateItemService;

        [HttpPut("/item/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update([FromBody] RequestItem request, [FromRoute] Guid id) {
            var service = _updateItemService;

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
