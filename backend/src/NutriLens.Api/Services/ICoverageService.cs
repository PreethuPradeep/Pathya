using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public interface ICoverageService
    {
        Task<NutritionCoverageDto>
        GetCoverageAsync(
            int userId);
    }
}
