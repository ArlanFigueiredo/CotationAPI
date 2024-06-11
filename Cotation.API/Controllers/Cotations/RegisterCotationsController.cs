using Cotation.API.Validators.Cotations;
using Cotation.Application.Services.SCotations;
using Cotation.Communication.ModelsViews.Requests.Cotations;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Cotations {
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterCotationsController(
        RegisterCotationService registerCotationService,
        ResponseErrorRegisterCotations responseErrorRegisterCotations
    ) : ControllerBase {
        private readonly RegisterCotationService _registerCotationService = registerCotationService;
        private readonly ResponseErrorRegisterCotations _responseErrorRegisterCotations = responseErrorRegisterCotations;

        [HttpPost("/cotations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register([FromBody] RequestCotations request) {
            var service = _registerCotationService;

            try {

                var erros = await _responseErrorRegisterCotations.GetErros(request);
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
