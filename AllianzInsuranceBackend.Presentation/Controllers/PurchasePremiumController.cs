using AllianzInsuranceBackend.Application.Interfaces;
using AllianzInsuranceBackend.Domain.DTO;
using AllianzInsuranceBackend.Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllianzInsuranceBackend.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasePremiumController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchasePremiumController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [ProducesResponseType(type: typeof(ApiResponse<PurchaseDto>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder(PurchaseDto dto)
        {
            try
            {
                var response = await _purchaseService.CreateOrder(dto);
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
