using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public interface IWeeklyReviewService
    {
        Task<WeeklyReviewDto> GetWeeklyReviewAsync(int userId);
    }
}
