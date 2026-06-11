using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public interface IRecommendationService
    {
        Task<List<NutrientRecomendationDto>> GetRecommendationsAsync(int userId);
    }
}
