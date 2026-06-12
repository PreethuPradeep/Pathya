using Pathya.Api.Data;
using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public class WeeklyReviewService : IWeeklyReviewService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAnalysisService _analysisService;
        private readonly IRecommendationService _recommendationService;
        private readonly IPatternService _patternService;
        private readonly INutrientImpactService _nutrientImpactService;
        public WeeklyReviewService(ApplicationDbContext context, IAnalysisService analysisService, IPatternService patternService, IRecommendationService recommendationService, INutrientImpactService nutrientImpactService)
        {
            _context = context;
            _analysisService = analysisService;
            _patternService = patternService;
            _recommendationService = recommendationService;
            _nutrientImpactService = nutrientImpactService;
        }
        public async Task<WeeklyReviewDto> GetWeeklyReviewAsync(int userId)
        {
            var analysis = await _analysisService.GetAnalysisAsync(userId);
            var patterns = await _patternService.GetPatternsAsync(userId);
            var recommendations = await _recommendationService.GetRecommendationsAsync(userId);

            var summary = new List<string>();
            foreach (var pattern in patterns)
            {
                summary.Add(
                    $"{pattern.Nutrient} intake {pattern.Pattern.ToLower()}");

                var impact =
                    await _nutrientImpactService
                        .GetInsightAsync(
                            pattern.Nutrient);

                if (impact != null)
                {
                    summary.Add(
                        $"{pattern.Nutrient} supports {impact.Supports}.");
                }
            }

            var advice = new List<string>();
            foreach(var recommendation in recommendations)
            {
                var foods = recommendation.Foods
                            .Take(3)
                            .ToList();
                if (foods.Any())
                {
                    advice.Add(
                        $"To improve {recommendation.Nutrient.ToLower()} intake, consider {string.Join(", ", foods)}.");
                }
            }
            return new WeeklyReviewDto
            {
                Summary = summary,
                Recommendations = advice
            };
        }
    }
}
