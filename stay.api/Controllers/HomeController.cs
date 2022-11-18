using Microsoft.AspNetCore.Mvc;

namespace stay.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration) : base(logger, configuration) 
        {
            _logger = logger;
        }

        [HttpGet(Name = "HomeController")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            try {
                await base.GetCurrentUserInfosAsync();
            }
            catch(Exception)
            {
                Unauthorized();
            }

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                User = Claims
            })
            .ToArray();
         }
    }
}