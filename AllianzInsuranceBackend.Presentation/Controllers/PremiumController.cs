using AllianzInsuranceBackend.Application.Interfaces;
using AllianzInsuranceBackend.Application.Services;
using AllianzInsuranceBackend.Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllianzInsuranceBackend.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        private readonly IPremiumService _premiumService;

        public PremiumController(IPremiumService premiumService)
        {
            _premiumService = premiumService;
        }

        [ProducesResponseType(type: typeof(ApiResponse<List<Car>>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [HttpGet("GetPremiums")]
        public async Task<IActionResult> GetPremiums()
        {
            try
            {
                var response = await _premiumService.GetAllPremium();
                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
