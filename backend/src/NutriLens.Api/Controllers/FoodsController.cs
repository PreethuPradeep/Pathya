using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pathya.Api.Data;
using Pathya.Api.Services;

namespace Pathya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodLogService _foodLogService;
        private readonly ApplicationDbContext _context;
        public FoodsController(IFoodLogService foodLogService, ApplicationDbContext context)
        {
            _context = context;
            _foodLogService = foodLogService;
        }
        [HttpGet]
        public async Task<IActionResult> GetFoods()
        {
            var foods = await _context.Foods
                .OrderBy(x => x.Name)
                .ToListAsync();

            return Ok(foods);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodLogItem(int id)
        {
            if (GetFoods == null)
            {
                return NotFound();
            }
            await _foodLogService.DeleteFoodLogItemAsync(id);
            return Ok();
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchFoods(string query)
        {
            var foods =
                await _context.Foods
                    .Where(x =>
                        x.Name
                            .ToLower()
                            .Contains(
                                query.ToLower()))
                    .OrderBy(x => x.Name)
                    .Take(20)
                    .ToListAsync();

            return Ok(foods);
        }
    }
}
