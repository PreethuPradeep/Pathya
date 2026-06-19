using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public interface IGapRecommendationService
    {
        Task<List<NutrientGapRecommendationDto>> GetGapRecommednationsAsync(int userId);
    }
}
