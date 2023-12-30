using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncOrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;


        private readonly ILogger<SyncOrderController> _logger;

        public SyncOrderController(ILogger<SyncOrderController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7020"); 

        }

        [HttpGet]
        [Route("GetCartData")]
        public async Task<IActionResult> GetCartData()
        {
            var response = await _httpClient.GetAsync($"/weatherforecast");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
