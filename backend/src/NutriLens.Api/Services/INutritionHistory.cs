using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public interface INutritionHistory
    {
        Task<List<NutritionHistoryDto>> GetNutritionHistoryAsync(int userId);
    }
}
