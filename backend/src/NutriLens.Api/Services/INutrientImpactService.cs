using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public interface INutrientImpactService
    {
        Task<NutrientInsightDto?> GetInsightAsync(string nutrientName);
    }
}
