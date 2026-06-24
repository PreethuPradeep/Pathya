using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    internal static class DailyNutritionHelpers
    {
        public static decimal GetNutrientAmount(
            IReadOnlyDictionary<DateOnly, List<ConsumeNutrientDto>> dailyNutrition,
            DateOnly date,
            string nutrientName)
        {
            if (!dailyNutrition.TryGetValue(date, out var nutrients))
            {
                return 0;
            }

            return nutrients
                .FirstOrDefault(x => x.Nutrient == nutrientName)
                ?.Amount ?? 0;
        }
    }
}
