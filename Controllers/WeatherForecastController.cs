using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MoviesProject.Controllers
{
    [ApiController]
    [Route("api/[Controller]/something")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly MySettings _mysettings;
        private readonly AnotherSettings _anothersettings;
        private readonly IConfiguration _configuration;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<MySettings> mysettingoptions,IOptions<AnotherSettings> anotherSettingsOptions, IConfiguration configuration)
        {
            _logger = logger;
            _mysettings = mysettingoptions.Value;
            _anothersettings = anotherSettingsOptions.Value;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var mySetting=_mysettings;
            var anotherSetting = _anothersettings;
            var mySettingskey1 = _configuration["MySettings:Key1"];
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //[HttpGet("getByid/{id}")]
        //[HttpGet]
        //public int GetById(int id )
        //{
        //    return id;
        //}
    }
}
