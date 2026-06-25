using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public class NutritionHistoryService : INutritionHistory
    {
        private readonly IDailyNutritionService _dailyNutritionService;
        public NutritionHistoryService(IDailyNutritionService dailyNutritionService)
        {
            _dailyNutritionService = dailyNutritionService;
        }
        public async Task<List<NutritionHistoryDto>> GetNutritionHistoryAsync(int userId)
        {
            var result = new List<NutritionHistoryDto>();

            for (int i = 29; i >= 0; i--)
            {
                var date = DateOnly.FromDateTime(DateTime.Today.AddDays(-i));
                var nutrients = await _dailyNutritionService.GetDailyNutrientsAsync(userId, date);

                if (nutrients.Any())
                {
                    result.Add(
                        new NutritionHistoryDto
                        {
                            Date = date,
                            Nutrients = nutrients
                        });
                }
            }
            return result;
        }
    }
}
