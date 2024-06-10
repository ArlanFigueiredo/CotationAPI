using Cotation.API.Validators.Product;
using Cotation.Application.Services.SProduct;
using Cotation.Communication.ModelsViews.Requests.Product;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Product {
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterProductController(
        RegisterProductService registerProductService,
        ResponseErrorRegisterProduct responseErrorRegisterProduct
    ) : ControllerBase {
        private readonly RegisterProductService _registerProductService = registerProductService;
        private readonly ResponseErrorRegisterProduct _responseErrorRegisterProduct = responseErrorRegisterProduct;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register([FromBody] RequestProduct request) {
            var service = _registerProductService;

            try {
                var erros = await _responseErrorRegisterProduct.GetErrors(request);
                if (erros.Count > 0) {
                    return BadRequest(erros);
                }
                var result = await service.Execute(request);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
