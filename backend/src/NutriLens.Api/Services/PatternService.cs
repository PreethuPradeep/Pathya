using Microsoft.EntityFrameworkCore;
using Pathya.Api.Data;
using Pathya.Api.DTOs;
using Pathya.Api.Entities;

namespace Pathya.Api.Services
{
    public class PatternService : IPatternService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRequirementService _requirementService;
        private readonly IDailyNutritionService _dailyNutritionService;

        public PatternService(
            ApplicationDbContext context,
            IRequirementService requirementService,
            IDailyNutritionService dailyNutritionService)
        {
            _context = context;
            _requirementService = requirementService;
            _dailyNutritionService = dailyNutritionService;
        }

        public async Task<List<PatternDto>>
            GetPatternsAsync(int userId)
        {
            var result = new List<PatternDto>();

            var requirements =
                await _requirementService
                    .GetRequirementsAsync(userId);

            var startDate =
                DateOnly.FromDateTime(
                    DateTime.Today.AddDays(-29));

            var endDate =
                DateOnly.FromDateTime(
                    DateTime.Today);

            foreach( var requirement in requirements)
            {
                var daysBelowTarget = 0;
                for ( var date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    var nutrients = await _dailyNutritionService.GetDailyNutrientsAsync(userId, date);
                    var consumed = nutrients.FirstOrDefault(x => x.Nutrient == requirement.Nutrient);
                    var amountConsumed = consumed?.Amount ?? 0;
                    if (amountConsumed < requirement.RequiredAmount)
                    {
                        daysBelowTarget++;
                    }
                }
                string pattern;
                if(daysBelowTarget >= 20)
                {
                    pattern = "Frequently below target";
                }
                else if (daysBelowTarget >= 10)
                {
                    pattern =
                        "Occasionally below target";
                }
                else
                {
                    pattern =
                        "Generally adequate";
                }
                result.Add(new PatternDto
                {
                    Nutrient = requirement.Nutrient,
                    DaysBelowTarget = daysBelowTarget,
                    Pattern = pattern
                });
            }
            return result;
        }

        
    }
}