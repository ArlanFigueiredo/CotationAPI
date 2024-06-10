using Cotation.Application.Services.SProduct;
using Cotation.Communication.ModelsViews.Requests.Product;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Product {
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateProductController(UpdateProductService updateProductService) : ControllerBase {
        private readonly UpdateProductService _updateProductService = updateProductService;

        [HttpPut("/product/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update([FromBody] RequestProduct request, [FromRoute] Guid id) {
            var service = _updateProductService;

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
