using Cotation.Application.Services.SCompany;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Company {
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteCompanyController(DeleteCompanyService deleteCompanyService) : ControllerBase {
        private readonly DeleteCompanyService _deleteCompanyService = deleteCompanyService;

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete([FromRoute] Guid id) {

            var service = _deleteCompanyService;

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
