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
            await _foodLogService.DeleteFoodLogItemAsync(id);
            return Ok();
        }
    }
}
