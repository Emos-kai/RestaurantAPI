using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService weatherForecast;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecast)
        {
            _logger = logger;
            this.weatherForecast = weatherForecast;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return weatherForecast.Get();
        }
        [HttpGet("curentDay/{max}")]
        public Dictionary<int, int> Get([FromQuery] int take, [FromRoute] int max)
        {
            Dictionary<int, int> maxTake = new Dictionary<int, int>() { { max, take } };
            return maxTake;
        }
        [HttpPost]
        public ActionResult<string> Hello([FromBody] string name)
        {
            HttpContext.Response.StatusCode = 404;
            return $"Hello {name}";
        }
        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery] int count,
            [FromBody] TemperatureRequest request)
        {
            if(count < 0 || request.TempMax < request.TempMin)
            {
                return BadRequest();
            }
            var result = weatherForecast.MyGet(count, request.TempMin, request.TempMax);
            return Ok(result);
        }
    }
}
