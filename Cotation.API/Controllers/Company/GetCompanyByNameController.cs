using Cotation.Application.Services.SCompany;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Company {
    [Route("api/[controller]")]
    [ApiController]
    public class GetCompanyByNameController(GetCompanyByNameService getCompanyByNameService) : ControllerBase {
        private readonly GetCompanyByNameService _getCompanyByNameService = getCompanyByNameService;

        [HttpGet("/company/name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetByName([FromRoute] string name) {
            var service = _getCompanyByNameService;

            try {
                var result = await service.Execute(name);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
