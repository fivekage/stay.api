using Ardalis.GuardClauses;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace stay.api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;
        private IConfiguration Configuration { get; }
        protected FirebaseToken Claims { get => claims; }

        private FirebaseToken? claims;

        protected BaseController(ILogger<BaseController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        protected async Task GetCurrentUserInfosAsync()
        {
            string token = Request.Headers["authorization"];
            Guard.Against.NullOrEmpty(token);
            HttpResponseMessage httpResponse;
            using (var httpClient = new HttpClient())
            {
                string uri = Configuration["AuthenticationURI"];
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);
                HttpRequestMessage httpRequestMessage = new(HttpMethod.Get, uri);
                httpResponse = httpClient.Send(httpRequestMessage);
            }

            try
            {
                httpResponse.EnsureSuccessStatusCode();
                if (httpResponse.Content == null) throw new HttpRequestException("Request succeeded but empty claims");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message);
                Unauthorized();
            }
            claims = JsonConvert.DeserializeObject<FirebaseToken>(await httpResponse.Content.ReadAsStringAsync());
        }
    }
}