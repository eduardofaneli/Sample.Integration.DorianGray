using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Integration.Api.Data.Interfaces;
using Sample.Integration.Api.Models;
using Sample.Integration.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Integration.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Creates a Weather Forecast.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /       
        ///     {
        ///        ...
        ///     }
        ///
        /// </remarks>
        /// <param name="forecast"></param>
        /// <returns>A newly created WeatherForecast</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]        
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Post(WeatherForecast forecast)
        {
            return Ok(forecast);
        }

        [AllowAnonymous]
        [HttpGet("dapper")]
        public IEnumerable<TesteDapper> Get(
            [FromServices] TesteDapperRepository repository)
        {
            return repository.Get();
        }

        [AllowAnonymous]
        [HttpPost("dapper")]
        public IActionResult PostDapper(
            [FromServices] IUnitOfWork unitOfWork,
            [FromServices] TesteDapperRepository repository,
            [FromBody] TesteDapper model)
        {
            unitOfWork.BeginTransaction();
            repository.Save(model);
            unitOfWork.Commit();
            return Ok();
        }
    }
}
