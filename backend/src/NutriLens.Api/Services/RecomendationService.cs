using Pathya.Api.Data;
using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public class RecomendationService : IRecommendationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAnalysisService _analysisService;
        public RecomendationService(ApplicationDbContext context, IAnalysisService analysisService)
        {
            _analysisService = analysisService;
            _context = context;
        }
        public Task<List<NutrientRecomendationDto>> GetRecommendationsAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
