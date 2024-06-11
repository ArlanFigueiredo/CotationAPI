using Cotation.Application.Services.SItem;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Item {
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllItemsController(GetAllItemService getAllItemService) : ControllerBase {
        private readonly GetAllItemService _getAllItemsService = getAllItemService;

        [HttpGet("/item")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> GetAllItems() {
            var service = _getAllItemsService;

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
