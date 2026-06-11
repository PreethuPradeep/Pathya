using Pathya.Api.Data;
using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public class AnalysisService : IAnalysisService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFoodLogService _foodLogService;
        private readonly IRequirementService _requirementService;
        public AnalysisService(ApplicationDbContext context, IFoodLogService foodLogService, IRequirementService requirementService)
        {
            _context = context;
            _foodLogService = foodLogService;
            _requirementService = requirementService;
            
        }
        public async Task<List<NutrientAnalysisDto>> GetAnalysisAsync(int userId)
        {
            var requirements = await _requirementService.GetRequirementsAsync(userId);
            var consumed = await _foodLogService.GetConsumedNutrientsAsync(userId);
            var consumedLookup = consumed.ToDictionary(x => x.Nutrient, x => x);
            var analysis = requirements.Select(r =>
            {
                consumedLookup.TryGetValue(r.Nutrient, out var consumedNutrient);
                var consumedAmount = consumedNutrient?.Amount ?? 0;
                var remaining = Math.Max(0, r.RequiredAmount - consumedAmount);
                var percentage = r.RequiredAmount == 0 ? 0 : consumedAmount / r.RequiredAmount * 100;
                return new NutrientAnalysisDto
                {
                    Nutrient = r.Nutrient,
                    Required = r.RequiredAmount,
                    Consumed = consumedAmount,
                    Remaining = Math.Round(remaining, 2),
                    PercentageMet = Math.Round(percentage, 2),
                    Unit = r.Unit
                };
            }).ToList();
            return analysis;
        }
    }
}
