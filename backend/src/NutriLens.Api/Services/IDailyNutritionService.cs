using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public interface IDailyNutritionService
    {
        Task<List<ConsumeNutrientDto>> GetDailyNutrientsAsync(int userId, DateOnly date);
    }
}
