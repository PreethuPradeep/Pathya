using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public interface IInsightService
    {
        Task<List<InsightDto>> GetInsights(int userId);
    }
}
