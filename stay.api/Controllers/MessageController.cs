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

        /// <summary>
        /// Get all messages of a channel
        /// </summary>
        /// <param name="chatroom"></param>
        /// <returns></returns>
        [HttpGet("{chatroom}/messages")]
        public async Task<IActionResult> GetMessages([FromRoute] string chatroom)
        {
            await base.GetCurrentUserInfosAsync();
            try
            {
                var result = await UseCase.HandleAsync(new MessagesGetRequest(chatroom));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Historize a message into a channel
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost("chatroom")]
        public async Task<IActionResult> AddMessage(
            [FromBody] ChannelMessageBodyRequest body)
        {
            await base.GetCurrentUserInfosAsync();

            try
            {
                var result = await UseCase.HandleAsync(new ChannelMessagePostRequest(body.ChatRoomUid, body.Message, body.WritedAt, body.WritedBy));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Historize a message between 2 users
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost("direct-link")]
        public async Task<IActionResult> AddPrivateMessage(
            [FromBody] PrivateMessageBodyRequest body)
        {
            await base.GetCurrentUserInfosAsync();

            try
            {
                var result = await UseCase.HandleAsync(new PrivateMessagePostRequest(body.Guid, body.Message, body.WritedAt, body.WritedBy));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}