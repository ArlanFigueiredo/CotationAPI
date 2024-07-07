using Cotation.Application.Services.SProduct;
using Cotation.Communication.ModelsViews.Requests.Product;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Product {
    [Route("api/[controller]")]
    [ApiController]
    public class GetProductsPaginationController(GetProductPaginationService getProductPaginationService) : ControllerBase {
        private readonly GetProductPaginationService _getProductPaginationService = getProductPaginationService;


        [HttpGet("/products/pagination/skip/{skip}/take/{take}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProductsAsync([FromRoute] int skip, int take) {
            var service = _getProductPaginationService;
            var requestList = new RequestListProduct {
                Skip = skip,
                Take = take
            };

            try {
                var result = await service.Execute(requestList);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

        }
    }
}
