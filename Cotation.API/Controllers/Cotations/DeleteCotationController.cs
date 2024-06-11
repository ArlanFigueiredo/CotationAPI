using Cotation.Application.Services.SCotations;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Cotations {
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteCotationController(DeleteCotationSerivce deleteCotationSerivce) : ControllerBase {
        private readonly DeleteCotationSerivce _deleteCotationService = deleteCotationSerivce;

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete([FromRoute] Guid id) {
            var service = _deleteCotationService;

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
