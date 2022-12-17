using Microsoft.AspNetCore.Mvc;
using stay.api.Models;
using stay.application.Interfaces;
using stay.application.Requests.ChatRoom;

namespace stay.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatRoomController : BaseController
    {
        private IChatRoomUseCase UseCase;

        public ChatRoomController(ILogger<UserController> logger, IConfiguration configuration, IChatRoomUseCase useCase) : base(logger, configuration)
        {
            UseCase = useCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(
            [FromRoute] string id)
        {
            await base.GetCurrentUserInfosAsync();
            if (String.IsNullOrEmpty(id))
                return BadRequest();
            try
            {
                var result = await UseCase.HandleAsync(new ChatRoomGetRequest(id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(
            [FromRoute] string id)
        {
            await base.GetCurrentUserInfosAsync();
            if (String.IsNullOrEmpty(id))
                return BadRequest();
            try
            {
                var result = await UseCase.HandleAsync(new ChatRoomDeleteRequest(id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllRooms()
        {
            await base.GetCurrentUserInfosAsync();
            try
            {
                var result = await UseCase.HandleAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(
            [FromBody] ChatRoomBodyRequest body)
        {
            await base.GetCurrentUserInfosAsync();
            try
            {
                var result = await UseCase.HandleAsync(new ChatRoomPostRequest(body.Uuid, body.CreatedBy, body.Longitude, body.Latitude));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}