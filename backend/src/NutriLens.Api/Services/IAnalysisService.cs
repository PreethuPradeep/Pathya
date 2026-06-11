using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public interface IAnalysisService
    {
        Task<List<NutrientAnalysisDto>> GetAnalysisAsync(int userId);
    }
}
