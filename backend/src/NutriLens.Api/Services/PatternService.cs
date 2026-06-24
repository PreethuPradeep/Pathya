using Pathya.Api.Data;
using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public class PatternService : IPatternService
    {
        private readonly IRequirementService _requirementService;
        private readonly IDailyNutritionService _dailyNutritionService;

        public PatternService(
            IRequirementService requirementService,
            IDailyNutritionService dailyNutritionService)
        {
            _requirementService = requirementService;
            _dailyNutritionService = dailyNutritionService;
        }

        public async Task<List<PatternDto>>
            GetPatternsAsync(int userId)
        {
            var result = new List<PatternDto>();

            var requirements =
                await _requirementService
                    .GetRequirementsAsync(userId);

            var startDate =
                DateOnly.FromDateTime(
                    DateTime.Today.AddDays(-29));

            var endDate =
                DateOnly.FromDateTime(
                    DateTime.Today);

            var dailyNutrition =
                await _dailyNutritionService
                    .GetDailyNutrientsForRangeAsync(
                        userId,
                        startDate,
                        endDate);

            foreach( var requirement in requirements)
            {
                var daysBelowTarget = 0;
                for ( var date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    var amountConsumed =
                        DailyNutritionHelpers.GetNutrientAmount(
                            dailyNutrition,
                            date,
                            requirement.Nutrient);

                    if (amountConsumed < requirement.RequiredAmount)
                    {
                        daysBelowTarget++;
                    }
                }
                string pattern;
                if(daysBelowTarget >= 20)
                {
                    pattern = "Frequently below target";
                }
                else if (daysBelowTarget >= 10)
                {
                    pattern =
                        "Occasionally below target";
                }
                else
                {
                    pattern =
                        "Generally adequate";
                }
                result.Add(new PatternDto
                {
                    Nutrient = requirement.Nutrient,
                    DaysBelowTarget = daysBelowTarget,
                    Pattern = pattern
                });
            }
            return result;
        }

        
    }
}
