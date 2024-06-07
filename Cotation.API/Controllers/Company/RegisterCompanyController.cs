using Cotation.API.Validators.Company;
using Cotation.Application.Services.SCompany;
using Cotation.Communication.ModelsViews.Requests.Company;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Company {
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterCompanyController(
        RegisterCompanyService registerCompanyService,
        ResponseErrorRegisterCompany responseErrorRegisterCompany
    ) : ControllerBase {
        private readonly RegisterCompanyService _registerCompanyService = registerCompanyService;
        private readonly ResponseErrorRegisterCompany _responseError = responseErrorRegisterCompany;

        [HttpPost("/company")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register([FromBody] RequestCompany request) {

            var service = _registerCompanyService;

            try {

                var errors = await _responseError.GetErrors(request);
                if (errors.Count > 0) {
                    return BadRequest(errors);
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
