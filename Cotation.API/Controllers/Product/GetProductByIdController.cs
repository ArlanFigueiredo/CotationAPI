using Cotation.Application.Services.SProduct;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Product {
    [Route("api/[controller]")]
    [ApiController]
    public class GetProductByIdController(GetProductByIdService getProductByIdService) : ControllerBase {
        private readonly GetProductByIdService _getProductByIdService = getProductByIdService;

        [HttpGet("/product/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetById([FromRoute] Guid id) {
            var service = _getProductByIdService;

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
