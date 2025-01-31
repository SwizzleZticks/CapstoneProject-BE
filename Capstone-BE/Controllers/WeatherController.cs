using Capstone_BE.Models;
using Capstone_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace Capstone_BE.Controllers;
public class WeatherController : BaseApiController
{
    private readonly WeatherService _service;

    public WeatherController(WeatherService service)
    {
        _service = service;
    }

    [HttpGet("daily")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<TimeLine>>GetTimeLineAsync([FromQuery] string location)
    {
        return Ok(await _service.GetSevenDayForecastAsync(location));
    }

    [HttpGet("day")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Day>> GetDayAsync([FromQuery] string location)
    {
        return Ok(await _service.GetDayForecastAsync(location));
    }

    [HttpGet("hourly")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Hour>> GetHourAsync([FromQuery] string location)
    {
        return Ok(await _service.GetHourlyForecastAsync(location));
    }
}