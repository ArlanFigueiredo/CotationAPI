using Cotation.Application.Services.SCompany;
using Cotation.Communication.ModelsViews.Requests.Company;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Company {
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateCompanyController(UpdateCompanyService updateCompanyService) : ControllerBase {
        private readonly UpdateCompanyService _updateCompanyService = updateCompanyService;

        [HttpPut("/company/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update([FromBody] RequestCompany request, [FromRoute] Guid id) {

            var service = _updateCompanyService;

            try {
                var result = await service.Execute(request, id);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
