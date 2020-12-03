using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Travel.WebApi.Controllers.v2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IEnumerable<WeatherForecast> Post(string city)
        {
            var rng = new Random();

            return Enumerable.Range(1, 14).Select(index =>
            {
                var celcius = rng.Next(-20, 55);

                return new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = celcius,
                    Summary = GetSummary(celcius),
                    City = city
                };
            })
            .ToArray();
        }

        private static string GetSummary(int temp)
        {
            if (temp >= -20 && temp <= -10)
            {
                return Summaries[0];
            }
            else if (temp >= -9 && temp <= 0)
            {
                return Summaries[1];
            }
            else if (temp >= 1 && temp <= 10)
            {
                return Summaries[2];
            }
            else if (temp >= 11 && temp <= 20)
            {
                return Summaries[3];
            }
            else if (temp >= 1 && temp <= 10)
            {
                return Summaries[4];
            }
            else if (temp >= 11 && temp <= 20)
            {
                return Summaries[5];
            }
            else if (temp >= 21 && temp <= 30)
            {
                return Summaries[6];
            }
            else if (temp >= 31 && temp <= 40)
            {
                return Summaries[7];
            }
            else if (temp >= 41 && temp <= 50)
            {
                return Summaries[8];
            }
            else if (temp >= 51 && temp <= 55)
            {
                return Summaries[9];
            }

            return "Not Advisable";
        }
    }
}
