using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pathya.Api.Services;

namespace Pathya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoverageController : ControllerBase
    {
        private readonly ICoverageService _coverageService;
        public CoverageController(ICoverageService coverageService)
        {
            _coverageService = coverageService;
        }
        [HttpGet("{userId}/coverage")]
        public async Task<IActionResult> GetCoverage(int userId)
        {
            var result = await _coverageService.GetCoverageAsync(userId);

            return Ok(result);
        }
    }
}
