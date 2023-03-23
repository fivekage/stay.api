using Microsoft.AspNetCore.Mvc;
using stay.api.Models;
using stay.application.Interfaces;
using stay.application.Requests.User;

namespace stay.api.Controllers
{
    /// <summary>
    /// User controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        public UserController(ILogger<UserController> logger, IConfiguration configuration) : base(logger, configuration)
        {
        }

        /// <summary>
        /// Get user informations
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="useCase"></param>
        /// <returns></returns>
        [HttpGet("{uid}")]
        public async Task<IActionResult> GetUserData([FromRoute] string uid, [FromServices] IUserUseCase useCase)
        {
            await base.GetCurrentUserInfosAsync();

            var result = await useCase.HandleAsync(new UserRequest(uid));
            return Ok(result);
        }

        /// <summary>
        /// Register or update an user into database
        /// </summary>
        /// <param name="request"></param>
        /// <param name="useCase"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> PostUserData([FromBody] UserBodyRequest request, [FromServices] IUserUseCase useCase)
        {
            await base.GetCurrentUserInfosAsync();

            var result = await useCase.HandleAsync(new UserPostRequest(request.Uid, request.Username, request.Email, request.AvatarURL));
            return Ok(result);
        }

        [HttpPost("add-friend")]
        public async Task<IActionResult> AddFriendRelation([FromBody] UserFriendBodyRequest request, [FromServices] IUserUseCase useCase)
        {
            await base.GetCurrentUserInfosAsync();

            var result = await useCase.HandleAsync(new FriendPostRequest(request.Me, request.FriendUid));
            return Ok(result);
        }
    }
}