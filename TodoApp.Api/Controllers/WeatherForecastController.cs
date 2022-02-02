using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TodoApp.Data;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "0Freezing", "1Bracing", "2Chilly", "3Cool", "4Mild", "5Warm", "6Balmy", "7Hot", "8Sweltering", "9Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly TodoDbContext db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            TodoDbContext todoDbContext)
        {
            _logger = logger;
            db = todoDbContext;
        }

        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            /*var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();*/
            return db.Todo;
        }
    }
}
