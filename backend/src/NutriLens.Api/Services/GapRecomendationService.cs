using Microsoft.EntityFrameworkCore;
using Pathya.Api.Data;
using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public class GapRecomendationService : IGapRecommendationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAnalysisService _analysisService;
        public GapRecomendationService(ApplicationDbContext context, IAnalysisService analysisService)
        {
            _context = context;
            _analysisService = analysisService;
        }
        public async Task<List<NutrientGapRecommendationDto>> GetGapRecommednationsAsync(int userId)
        {
            var analysis = await _analysisService.GetAnalysisAsync(userId);
            var result = new List<NutrientGapRecommendationDto>();
            foreach(var nutrient in analysis)
            {
                if (nutrient.Remaining <= 0)
                {
                    continue;
                }
                var foodOptions = await _context.nutrientFoodRecomendations.Where(x => x.Nutrient.Name == nutrient.Nutrient).ToListAsync();
                var foodDtos = new List<FoodGapRecommendationDto>();
                foreach(var recommendation in foodOptions)
                {
                    var food = await _context.Foods.FirstOrDefaultAsync(x => x.Name == recommendation.FoodName);
                    if (food == null)
                    {
                        continue;
                    }
                    var foodNutrient = await _context.FoodNutrients.FirstOrDefaultAsync(x => x.FoodId == food.Id && x.Nutrient.Name == nutrient.Nutrient);

                    if (foodNutrient == null || foodNutrient.AmountPer100g <= 0)
                    {
                        continue;
                    }
                    var gramsNeeded = nutrient.Remaining / foodNutrient.AmountPer100g * 100;
                    
                    foodDtos.Add(new FoodGapRecommendationDto
                    {
                        Food = recommendation.FoodName,
                        GramsNeeded = Math.Round(gramsNeeded, 2),
                        Reason = recommendation.Reason
                    });
                }
                if (!foodDtos.Any())
                {
                    continue;
                }
                result.Add(new NutrientGapRecommendationDto
                {
                    Nutrient = nutrient.Nutrient,
                    RemainingAmount = nutrient.Remaining,
                    Unit = nutrient.Unit,
                    PercentageMet = Math.Round(nutrient.PercentageMet,2),
                    Foods = foodDtos.Where(x=>x.GramsNeeded <= 500).OrderBy(x => x.GramsNeeded).Take(3).ToList(),
                });
            }
            return result;
        }
    }
}
