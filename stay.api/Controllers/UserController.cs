using FirebaseAdmin;
using FireSharp;
using Microsoft.AspNetCore.Mvc;
using stay.application.Interfaces;
using stay.application.Requests;
using System.Net;

namespace stay.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        public UserController(ILogger<UserController> logger, IConfiguration configuration) : base(logger, configuration) { }

        [HttpGet]
        public async Task<IActionResult> GetUserData([FromServices] IFirebaseUseCase useCase)
        {
            await base.GetCurrentUserInfosAsync();

            var result = await useCase.HandleAsync(new FirebaseUseCaseRequest(Claims.Uid));
            return Ok(result);

            /*return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                User = Claims
            })
            .ToArray();*/
         }
    }
}