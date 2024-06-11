using Cotation.API.Validators.Cotations;
using Cotation.Application.Services.SCotations;
using Cotation.Communication.ModelsViews.Requests.Cotations;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Cotations {
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateCotationController(
        UpdateCotationService updateCotationService,
        ResponseErrorRegisterCotations responseErrorRegisterCotations

    ) : ControllerBase {
        private readonly UpdateCotationService _updateCotationService = updateCotationService;
        private readonly ResponseErrorRegisterCotations _responseErrorRegisterCotations = responseErrorRegisterCotations;

        [HttpPut("/cotation/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update([FromBody] RequestCotations request, [FromRoute] Guid id) {
            var service = _updateCotationService;

            try {
                var erros = await _responseErrorRegisterCotations.GetErros(request);
                if (erros.Count > 0) {
                    return BadRequest(erros);
                }

                var result = await service.Execute(request, id);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
