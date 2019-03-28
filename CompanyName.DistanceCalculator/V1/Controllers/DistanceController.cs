using System.Collections.Generic;
using CompanyName.DistanceCalculator.V1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyName.DistanceCalculator.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DistanceController : ControllerBase
    {
        public DistanceController()
        {

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

            var responseDto = new CalculateDistanceResponseDto(0);
            return Ok(responseDto);
        }
    }
}
