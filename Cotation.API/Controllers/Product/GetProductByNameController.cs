using Cotation.Application.Services.SProduct;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Product {
    [Route("api/[controller]")]
    [ApiController]
    public class GetProductByNameController(GetProductByNameService getProductByNameService) : ControllerBase {
        private readonly GetProductByNameService _getProductByNameService = getProductByNameService;

        [HttpGet("/product/name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetByName([FromRoute] string name) {
            var service = _getProductByNameService;

            try {
                var result = await service.Execute(name);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
