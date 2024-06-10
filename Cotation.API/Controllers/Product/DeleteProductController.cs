using Cotation.Application.Services.SProduct;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Product {
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteProductController(DeleteProductService deleteProductService) : ControllerBase {
        private readonly DeleteProductService _deleteProductService = deleteProductService;

        [HttpDelete("product/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete([FromRoute] Guid id) {
            var service = _deleteProductService;

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
