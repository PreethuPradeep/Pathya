using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public class TrendService : ITrendService
    {
        private readonly IDailyNutritionService
        _dailyNutritionService;

        private readonly IRequirementService
            _requirementService;

        public TrendService(
            IDailyNutritionService dailyNutritionService,
            IRequirementService requirementService)
        {
            _dailyNutritionService =
                dailyNutritionService;

            _requirementService =
                requirementService;
        }
        public async Task<List<NutrientTrendDto>> GetTrendsAsync(int userId)
        {
            var requirements = await _requirementService.GetRequirementsAsync(userId);
            var result = new List<NutrientTrendDto>();
            var currentWeekStart = DateOnly.FromDateTime(DateTime.Today.AddDays(-6));
            var previousWeekStart = DateOnly.FromDateTime(DateTime.Today.AddDays(-13));
            var previousWeekEnd = DateOnly.FromDateTime(DateTime.Today.AddDays(-7));
            foreach( var requirement in requirements)
            {
                decimal currentWeekTotal = 0;
                decimal previousWeekTotal = 0;
                for (var date = currentWeekStart; date <= DateOnly.FromDateTime(DateTime.Today) ; date = date.AddDays(1))
                {
                    var nutrients = await _dailyNutritionService.GetDailyNutrientsAsync(userId, date);
                    currentWeekTotal += nutrients.FirstOrDefault(x => x.Nutrient == requirement.Nutrient)?.Amount ?? 0;
                }
                for (var date = previousWeekStart; date <= previousWeekEnd; date = date.AddDays(1))
                {
                    var nutrients = await _dailyNutritionService.GetDailyNutrientsAsync(userId, date);
                    previousWeekTotal += nutrients.FirstOrDefault(x => x.Nutrient == requirement.Nutrient)?.Amount ?? 0;
                }
                var currentAverage = currentWeekTotal / 7;
                var previousAverage = previousWeekTotal / 7;
                decimal changePercent = 0;

                if (previousAverage > 0)
                {
                    changePercent =
                        ((currentAverage - previousAverage)
                        / previousAverage)
                        * 100;
                }

                string trend;

                if (previousAverage == 0 &&
                    currentAverage > 0)
                {
                    trend = "New Intake";
                }
                else if (changePercent >= 50)
                {
                    trend = "Strongly Improving";
                }
                else if (changePercent >= 10)
                {
                    trend = "Improving";
                }
                else if (changePercent <= -50)
                {
                    trend = "Strongly Declining";
                }
                else if (changePercent <= -10)
                {
                    trend = "Declining";
                }
                else
                {
                    trend = "Stable";
                }
                string insight;

                if (trend == "New Intake")
                {
                    insight =
                        $"{requirement.Nutrient} appeared in your diet this week.";
                }
                else if (trend == "Strongly Improving")
                {
                    insight =
                        $"{requirement.Nutrient} increased significantly compared to last week.";
                }
                else if (trend == "Improving")
                {
                    insight =
                        $"{requirement.Nutrient} improved compared to last week.";
                }
                else if (trend == "Strongly Declining")
                {
                    insight =
                        $"{requirement.Nutrient} decreased significantly compared to last week.";
                }
                else if (trend == "Declining")
                {
                    insight =
                        $"{requirement.Nutrient} decreased compared to last week.";
                }
                else
                {
                    insight =
                        $"{requirement.Nutrient} remained stable.";
                }
                result.Add(new NutrientTrendDto
                {
                    Nutrient = requirement.Nutrient,
                    PreviousWeekAverage = Math.Round(previousAverage, 2),
                    CurrentWeekAverage = Math.Round(currentAverage, 2),
                    ChangePercent = Math.Round(changePercent, 2),
                    Trend = trend,
                    Insight = insight
                });
                
            }
            return result;
        }
    }
}
