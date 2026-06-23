using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pathya.Api.Services;

namespace Pathya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeeklyReviewsController : ControllerBase
    {
        private readonly IWeeklyReviewService _weeklyReviewService;
        public WeeklyReviewsController(IWeeklyReviewService weeklyReviewService)
        {
            _weeklyReviewService = weeklyReviewService;
        }
        [HttpGet("{userId}/weekly-review")]
        public async Task<IActionResult>GetWeeklyReview(int userId)
        {
            var result =
                await _weeklyReviewService
                    .GetWeeklyReviewAsync(userId);

            return Ok(result);
        }
    }
}
