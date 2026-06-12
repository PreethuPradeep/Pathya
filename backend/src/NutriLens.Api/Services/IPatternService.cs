using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public interface IPatternService
    {
        Task<List<PatternDto>> GetPatternsAsync(int userId);
    }
}
