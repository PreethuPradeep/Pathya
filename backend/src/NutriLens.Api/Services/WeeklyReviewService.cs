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
        public WeeklyReviewService(ApplicationDbContext context, IAnalysisService analysisService, IPatternService patternService, IRecommendationService recommendationService)
        {
            _context = context;
            _analysisService = analysisService;
            _patternService = patternService;
            _recommendationService = recommendationService;
        }
        public async Task<WeeklyReviewDto> GetWeeklyReviewAsync(int userId)
        {
            var analysis = await _analysisService.GetAnalysisAsync(userId);
            var patterns = await _patternService.GetPatternsAsync(userId);
            var recommendations = await _recommendationService.GetRecommendationsAsync(userId);

            var summary = new List<string>();
            foreach (var pattern in patterns)
            {
                summary.Add($"{pattern.Nutrient}: {pattern.Pattern}");
            }

            var advice = new List<string>();
            foreach(var recommendation in recommendations)
            {
                var food = recommendation.Foods.FirstOrDefault();
                if (food != null)
                {
                    advice.Add($"Consider adding more {food}");
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
