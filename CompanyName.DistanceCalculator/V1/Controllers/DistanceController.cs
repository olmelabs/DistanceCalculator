using CompanyName.DistanceCalculator.Services.Interfaces;
using CompanyName.DistanceCalculator.V1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyName.DistanceCalculator.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DistanceController : ControllerBase
    {
        private readonly IDistanceCalculator _calculator;
        public DistanceController(IDistanceCalculator calculator)
        {
            _calculator = calculator;
        }

        // GET api/values. 
        [HttpGet]
        [ProducesResponseType(typeof(double), 202)]
        [ProducesResponseType(400)]
        public ActionResult<CalculateDistanceResponseDto> Get(CalculateDistanceRequestDto dto)
        {
            //TODO: we can make it async but there is no point as no DB or other long operations here.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var distance = _calculator.Calculate(dto.Latitude1.Value, dto.Longtitude1.Value, dto.Latitude2.Value, dto.Longtitude2.Value);
            var responseDto = new CalculateDistanceResponseDto(distance);

            return Ok(responseDto);
        }
    }
}
