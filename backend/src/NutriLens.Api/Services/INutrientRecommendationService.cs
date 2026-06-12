using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public interface INutrientRecommendationService
    {
        Task<List<FoodRecommendationDto>> GetFoodsForNutrientAsync(string nutrientName);
    }
}
