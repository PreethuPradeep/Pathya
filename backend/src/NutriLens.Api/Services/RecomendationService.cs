using Pathya.Api.Data;
using Pathya.Api.DTOs;
using Pathya.Api.Entities;

namespace Pathya.Api.Services
{
    public class RecomendationService : IRecommendationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAnalysisService _analysisService;
        private readonly INutrientRecommendationService _nutrientRecommendationService;
        public RecomendationService(ApplicationDbContext context, IAnalysisService analysisService, INutrientRecommendationService nutrientRecommendationService)
        {
            _analysisService = analysisService;
            _nutrientRecommendationService = nutrientRecommendationService;
            _context = context;
        }
        public async Task<List<NutrientRecomendationDto>> GetRecommendationsAsync(int userId)
        {
            var analysis = await _analysisService.GetAnalysisAsync(userId);
            var lowNutrients = analysis.Where(x => x.Remaining > 0).ToList();
            var result = new List<NutrientRecomendationDto>();
            foreach (var nutrient in lowNutrients)
            {
                var foods = await _nutrientRecommendationService.GetFoodsForNutrientAsync(nutrient.Nutrient);
                result.Add(new NutrientRecomendationDto
                {
                    Nutrient = nutrient.Nutrient,
                    Remaining = nutrient.Remaining,
                    Foods = foods.Select(x => x.Food).ToList()

                });
            }
            return result;
        }
    }
}
