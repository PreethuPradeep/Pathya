using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public class CoverageService : ICoverageService
    {
        private readonly IAnalysisService _analysisService;
        public CoverageService(IAnalysisService analysisService)
        {
            _analysisService = analysisService;
        }

        public async Task<NutritionCoverageDto> GetCoverageAsync(int userId)
        {
            var analysis = await _analysisService.GetAnalysisAsync(userId);
            var met = analysis.Count(x => x.PercentageMet >= 100);
            var tracked = analysis.Count;

            var missing = analysis.Where(x => x.PercentageMet < 100)
                .Select(x => x.Nutrient)
                .ToList();
            var percentage = tracked == 0 ? 0 : (decimal)met / tracked * 100;
            return new NutritionCoverageDto
            {
                TrackedNutrients = tracked,
                MetNutrients = met,
                CoveragePercentage =
                    Math.Round(
                        percentage,
                        2),

                MissingNutrients =
                    missing
            };
        }
    }
}
