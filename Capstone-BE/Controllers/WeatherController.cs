using Capstone_BE.Models;
using Capstone_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace Capstone_BE.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : Controller
{
    private readonly WeatherService _service;

    public WeatherController(WeatherService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<TimeLine>>GetTimeLineAsync([FromQuery] string location)
    {
        return Ok(await _service.GetSevenDayForecastAsync(location));
    }
    
}