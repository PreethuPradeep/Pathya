using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public interface IFoodLogService
    {
        Task AddFoodAsync(CreateFoodLogDto request);
        Task<List<ConsumeNutrientDto>> GetConsumedNutrientsAsync(int userId);
    }
}
