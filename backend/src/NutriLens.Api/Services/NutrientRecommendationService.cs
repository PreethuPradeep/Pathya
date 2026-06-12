using Microsoft.EntityFrameworkCore;
using Pathya.Api.Data;
using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public class NutrientRecommendationService : INutrientRecommendationService
    {
        private readonly ApplicationDbContext _context;
        public NutrientRecommendationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<FoodRecommendationDto>> GetFoodsForNutrientAsync(string nutrientName)
        {
            return await _context.FoodNutrients
                .Include(x => x.Food)
                .Include(x => x.Nutrient)
                .Where(x => x.Nutrient.Name == nutrientName)
                .OrderByDescending(x => x.AmountPer100g)
                .Take(5)
                .Select(x => new FoodRecommendationDto
                {
                    Food = x.Food.Name,
                    Amount = x.AmountPer100g,
                    Unit = x.Nutrient.Unit
                }).ToListAsync();
        }
    }
}
