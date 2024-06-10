using Cotation.Application.Services.SProduct;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Product {
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllProductsController(GetAllProductService getAllProductService) : ControllerBase {
        private readonly GetAllProductService _getAllProductService = getAllProductService;

        [HttpGet("/products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> GetAll() {
            var service = _getAllProductService;

            try {
                var result = await _getAllProductService.Execute();
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
