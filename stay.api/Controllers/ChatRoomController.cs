using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using stay.api.Models;
using stay.application.Extensions;
using stay.application.Interfaces;
using stay.application.Models;
using stay.application.Requests.ChatRoom;
using System.Globalization;

namespace stay.api.Controllers
{
    [ApiController]
    [Route("api/chat-room")]
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
                var result = await UseCase.HandleAsync(new ChatRoomPostRequest(
                    body.Name.CapitalizeFirstLetter(), 
                    body.Description.CapitalizeFirstLetter(),
                    body.CreatedBy.CapitalizeFirstLetter(), 
                    true, 
                    body.Longitude,
                    body.Latitude, 
                    body.Radius,
                    body.Color));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        /// <summary>
        /// Get Rooms in a dimension of 5km around a location given by the user
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRoomsByLocation(
            [FromQuery] string longitude,
            [FromQuery] string latitude)
        {
            await base.GetCurrentUserInfosAsync();
            if (String.IsNullOrEmpty(longitude) || String.IsNullOrEmpty(latitude))
                return BadRequest();

            try
            {
                IEnumerable<ChatRoom> result = await UseCase.HandleAsync(new ChatRoomGetByLocationRequest(double.Parse(longitude, CultureInfo.InvariantCulture), double.Parse(latitude, CultureInfo.InvariantCulture)));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}