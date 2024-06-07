using Cotation.Application.Services.SCompany;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Company {
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllCompanyController(GetAllCompanyService getAllCompanyService) : ControllerBase {
        private readonly GetAllCompanyService _getAllCompanyService = getAllCompanyService;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAll() {
            var service = _getAllCompanyService;

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
