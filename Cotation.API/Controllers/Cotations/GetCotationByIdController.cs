using Cotation.Application.Services.SCotations;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Cotations {
    [Route("api/[controller]")]
    [ApiController]
    public class GetCotationByIdController(GetCotationByIdService getCotationByIdService) : ControllerBase {
        private readonly GetCotationByIdService _getCotationByIdService = getCotationByIdService;

        [HttpGet("/cotation/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetById([FromRoute] Guid id) {
            var service = _getCotationByIdService;

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
