using Cotation.Application.Services.SCotations;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Cotations {
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllCotationsController(GetAllCotationsService getAllCotationsService) : ControllerBase {
        private readonly GetAllCotationsService _getAllCotationsService = getAllCotationsService;

        [HttpGet("/cotations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAll() {
            var service = _getAllCotationsService;

            try {
                var result = await service.Execute();
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
