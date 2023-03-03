using Microsoft.AspNetCore.Mvc;
using stay.api.Models;
using stay.application.Interfaces;
using stay.application.Requests.Message;

namespace stay.api.Controllers
{
    [ApiController]
    [Route("api/message")]
    public class MessageController : BaseController
    {
        private readonly IMessageUseCase UseCase;

        public MessageController(ILogger<UserController> logger, IConfiguration configuration, IMessageUseCase useCase) : base(logger, configuration)
        {
            UseCase = useCase;
        }

        [HttpPost()]
        public async Task<IActionResult> GetRoom(
            [FromBody] MessageBodyRequest body)
        {
            await base.GetCurrentUserInfosAsync();

            try
            {
                var result = await UseCase.HandleAsync(new MessagePostRequest(body.ChatRoomUid, body.Message, body.WritedAt, body.WritedBy));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}