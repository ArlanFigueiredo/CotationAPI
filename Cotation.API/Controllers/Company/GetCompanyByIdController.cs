using Cotation.Application.Services.SCompany;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Company {
    [Route("api/[controller]")]
    [ApiController]
    public class GetCompanyByIdController(GetCompanyByIdService getCompanyByIdService) : ControllerBase {
        private readonly GetCompanyByIdService _getCompanyByIdService = getCompanyByIdService;

        [HttpGet("/company/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetById([FromRoute] Guid id) {
            var service = _getCompanyByIdService;

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
