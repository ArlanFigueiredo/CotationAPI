using Cotation.Application.Services.SItem;
using Microsoft.AspNetCore.Mvc;

namespace Cotation.API.Controllers.Item {
    [Route("api/[controller]")]
    [ApiController]
    public class GetItemByCompanyController(GetItemsByCompanyServices getItemsByCompanyServices) : ControllerBase {
        private readonly GetItemsByCompanyServices _getItemsByCompanyServices = getItemsByCompanyServices;

        [HttpGet("/item/companyId/{companyId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetByCompanyId([FromRoute] Guid companyId) {
            var service = _getItemsByCompanyServices;

            try {
                var result = await service.Execute(companyId);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

        }
    }
}
