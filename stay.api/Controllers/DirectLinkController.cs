using Microsoft.AspNetCore.Mvc;
using stay.api.Models;
using stay.application.Interfaces;
using stay.application.Requests.DirectLink;

namespace stay.api.Controllers
{
    [ApiController]
    [Route("api/direct-link")]
    public class DirectLinkController : BaseController
    {
        private readonly IDirectLinkUseCase UseCase;

        public DirectLinkController(ILogger<DirectLinkController> logger, IConfiguration configuration, IDirectLinkUseCase useCase) : base(logger, configuration)
        {
            UseCase = useCase;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetDirectLinks([FromQuery] string me)
        {
            await base.GetCurrentUserInfosAsync();
            try
            {
                if (string.IsNullOrEmpty(me))
                    throw new ArgumentException("{useruuid} is mandatory");
                var result = await UseCase.HandleAsync(new DirectLinksGetRequest(me));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        public async Task<IActionResult> GetDirectLink([FromQuery] string me, [FromQuery] string useruuid)
        {
            await base.GetCurrentUserInfosAsync();
            try
            {
                if (string.IsNullOrEmpty(useruuid) || string.IsNullOrEmpty(me))
                    throw new ArgumentException("{useruuid} and {me} are mandatory");
                var result = await UseCase.HandleAsync(new DirectLinkGetRequest(useruuid, me));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> AddLink(
            [FromBody] DirectLinkBodyRequest body)
        {
            await base.GetCurrentUserInfosAsync();

            try
            {
                var result = await UseCase.HandleAsync(new DirectLinkPostRequest(body.me, body.useruuid));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}