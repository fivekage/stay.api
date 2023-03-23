using Microsoft.AspNetCore.Mvc;
using stay.api.Models;
using stay.application.Interfaces;
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

        [HttpGet("{uid}")]
        public async Task<IActionResult> GetUserData([FromRoute] string uid, [FromServices] IUserUseCase useCase)
        {
            await base.GetCurrentUserInfosAsync();

            var result = await useCase.HandleAsync(new UserRequest(uid));
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> PostUserData([FromBody] UserBodyRequest request, [FromServices] IUserUseCase useCase)
        {
            await base.GetCurrentUserInfosAsync();

            var result = await useCase.HandleAsync(new UserPostRequest(request.Uid, request.Username, request.Email, request.AvatarURL));
            return Ok(result);
        }
    }
}