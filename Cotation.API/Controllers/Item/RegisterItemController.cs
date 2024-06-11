using Cotation.API.Validators.Item;
using Cotation.Application.Services.SItem;
using Cotation.Communication.ModelsViews.Requests.Item;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Item {
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterItemController(
        RegisterItemService registerItemService,
        ResponseErrorRegisterItem responseErrorRegisterItem
    ) : ControllerBase {
        private readonly RegisterItemService _registerItemService = registerItemService;
        private readonly ResponseErrorRegisterItem _responseErrorRegisterItem = responseErrorRegisterItem;
        [HttpPost("/item")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register([FromBody] RequestItem request) {
            var service = _registerItemService;

            try {
                var erros = await _responseErrorRegisterItem.GetErros(request);
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

