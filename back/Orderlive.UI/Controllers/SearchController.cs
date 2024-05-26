using Microsoft.AspNetCore.Mvc;
using OrderLive.Infrastructure.Services;

namespace Orderlive.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SearchController : ControllerBase
    {
        private readonly OpenAIService _openApiService;

        public SearchController(OpenAIService openApiService)
        {
            _openApiService = openApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string question)
        {
            var response = await _openApiService.Questions(question);
            return Ok(response);
        }
    }
}
