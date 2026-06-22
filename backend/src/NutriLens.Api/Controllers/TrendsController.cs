using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pathya.Api.Services;

namespace Pathya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrendsController : ControllerBase
    {
        private readonly ITrendService _trendService;
        public TrendsController(ITrendService trendService)
        {
            _trendService = trendService;
        }
        [HttpGet("{userId}/trends")]
        public async Task<IActionResult>GetTrends(int userId)
        {
            var result =
                await _trendService.GetTrendsAsync(userId);

            return Ok(result);
        }
    }
}
