using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Travel.WebApi.Controllers.v2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpPost]
        public IEnumerable<WeatherForecast> Post(string city)
        {
            var rng = new Random();

            return Enumerable.Range(1, 14).Select(index =>
            {
                var celsius = rng.Next(-5, 44);

                return new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = celsius,
                    Summary = GetSummary(celsius),
                    City = city
                };
            }).ToArray();
        }

        private static string GetSummary(int temp)
        {
            if (temp >= -5 && temp <= -1) return Summaries[0];
            if (temp >= 0 && temp <= 4) return Summaries[1];
            if (temp >= 5 && temp <= 9) return Summaries[2];
            if (temp >= 10 && temp <= 14) return Summaries[3];
            if (temp >= 15 && temp <= 19) return Summaries[4];
            if (temp >= 20 && temp <= 24) return Summaries[5];
            if (temp >= 25 && temp <= 29) return Summaries[6];
            if (temp >= 30 && temp <= 34) return Summaries[7];
            if (temp >= 35 && temp <= 39) return Summaries[8];
            if (temp >= 40 && temp <= 44) return Summaries[9];

            return "Extreme";
        }
    }
}
