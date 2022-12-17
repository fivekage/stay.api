using Microsoft.AspNetCore.Mvc;
using stay.application.Interfaces;
using stay.application.Requests;
using stay.application.Requests.User;

namespace stay.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        public UserController(ILogger<UserController> logger, IConfiguration configuration) : base(logger, configuration)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetUserData([FromServices] IUserUseCase useCase)
        {
            await base.GetCurrentUserInfosAsync();

            var result = await useCase.HandleAsync(new UserRequest(Claims.Uid));
            return Ok(result);
        }
    }
}