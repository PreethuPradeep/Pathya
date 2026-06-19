using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public interface ITrendService
    {
        Task<List<NutrientTrendDto>> GetTrendsAsync(int userId);
    }
}
