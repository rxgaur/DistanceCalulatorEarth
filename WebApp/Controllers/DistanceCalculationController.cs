using DistanceCalculator.Domain.ViewModel;
using DistanceCalculator.ServiceLayer;
using DistanceCalculator.ServiceLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class DistanceCalculationController : ControllerBase
    {
        private readonly IGeoPositionCalculator _getGeoPositionCalculator;
        public DistanceCalculationController(IGeoPositionCalculator getGeoPositionCalculator)
        {
            _getGeoPositionCalculator = getGeoPositionCalculator;
        }

        [HttpGet(nameof(GetDistance), Name = nameof(GetDistance)), ProducesResponseType(200), ProducesResponseType(400)]
        public async Task<IActionResult> GetDistance([FromBody]Coordinates coordinates)
        {
            if (coordinates.To == null || coordinates.From == null || coordinates.To.IsEqual(coordinates.From) || !ModelState.IsValid)
                return BadRequest();

            var distance = await _getGeoPositionCalculator.GetDistanceAsync(coordinates.From, coordinates.To);

            if (Math.Abs(distance - double.MinValue) < 0)
                return BadRequest();
            return Ok(distance);
        }
    }
}