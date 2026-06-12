using Pathya.Api.Data;
using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public class PatternService : IPatternService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAnalysisService _analysisService;
        public PatternService(ApplicationDbContext context, IAnalysisService analysisService)
        {
            _context = context;
            _analysisService = analysisService;
        }
        public async Task<List<PatternDto>> GetPatternsAsync(int userId)
        {
            var analysis = await _analysisService.GetAnalysisAsync(userId);
            var result = new List<PatternDto>();
            foreach (var nutrient in analysis)
            {
                string pattern;
                if (nutrient.PercentageMet < 40)
                    {
                        pattern = "Consistently below target.";
                    }
                    else if (nutrient.PercentageMet < 80)
                    {
                        pattern =
                            "Often below target.";
                    }
                    else
                    {
                        pattern =
                            "Generally adequate.";
                    }

                result.Add(
                    new PatternDto
                    {
                        Nutrient = nutrient.Nutrient,
                        Pattern = pattern
                    });
                }
            return result;
            }
        }
    }

