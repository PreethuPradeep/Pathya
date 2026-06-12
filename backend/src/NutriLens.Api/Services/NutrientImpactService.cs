using Microsoft.EntityFrameworkCore;
using Pathya.Api.Data;
using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public class NutrientImpactService : INutrientImpactService
    {
        private readonly ApplicationDbContext _context;
        public NutrientImpactService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<NutrientInsightDto?> GetInsightAsync(string nutrientName)
        {
            return await _context.NutrientImpacts
                .Where(x => x.NutrientName == nutrientName)
                .Select(x =>
                new NutrientInsightDto
                {
                    Nutrient = x.NutrientName,
                    Supports = x.Supports,
                    Recommendation =
                    x.RecommendationText
                })
                .FirstOrDefaultAsync();
        }
    }
}
