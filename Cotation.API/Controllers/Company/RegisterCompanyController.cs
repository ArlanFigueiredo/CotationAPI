using Cotation.Application.Services.SCompany;
using Cotation.Communication.ModelsViews.Requests.Company;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Company {
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterCompanyController(RegisterCompanyService registerCompanyService) : ControllerBase {
        private readonly RegisterCompanyService _registerCompanyService = registerCompanyService;

        [HttpPost("/company")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register([FromBody] RequestCompany request) {

            var service = _registerCompanyService;

            try {
                var result = await service.Execute(request);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);  
            }

        }
    }
}
