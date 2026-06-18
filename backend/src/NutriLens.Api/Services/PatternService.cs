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

        public PatternService(
            ApplicationDbContext context,
            IRequirementService requirementService)
        {
            _context = context;
            _requirementService = requirementService;
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

            var foodLogItems =
                await _context.FoodLogItems
                    .Include(x => x.FoodLog)
                    .Where(x =>
                        x.FoodLog.UserId == userId &&
                        x.FoodLog.Date >= startDate &&
                        x.FoodLog.Date <= endDate)
                    .ToListAsync();

            var foodNutrients =
                await _context.FoodNutrients
                    .Include(x => x.Nutrient)
                    .ToListAsync();

            foreach (var requirement in requirements)
            {
                result.Add(
                    BuildPattern(
                        requirement,
                        foodLogItems,
                        foodNutrients,
                        startDate,
                        endDate));
            }

            return result;
        }

        private PatternDto BuildPattern(
            NutrientRequirementDto requirement,
            List<FoodLogItem> foodLogItems,
            List<FoodNutrient> foodNutrients,
            DateOnly startDate,
            DateOnly endDate)
        {
            var daysBelowTarget = 0;
            var loggedDays = 0;

            for (
                var date = startDate;
                date <= endDate;
                date = date.AddDays(1))
            {
                var dailyItems =
                    foodLogItems
                        .Where(x =>
                            x.FoodLog.Date == date)
                        .ToList();

                if (!dailyItems.Any())
                {
                    continue;
                }

                loggedDays++;

                decimal consumed = 0;

                foreach (var item in dailyItems)
                {
                    var nutrient =
                        foodNutrients
                            .FirstOrDefault(x =>
                                x.FoodId == item.FoodId &&
                                x.Nutrient.Name ==
                                    requirement.Nutrient);

                    if (nutrient == null)
                    {
                        continue;
                    }

                    consumed +=
                        item.WeightInGrams *
                        nutrient.AmountPer100g /
                        100m;
                }

                if (consumed < requirement.RequiredAmount)
                {
                    daysBelowTarget++;
                }
            }

            var percentageBelow =
                loggedDays == 0
                    ? 0
                    : (decimal)daysBelowTarget /
                      loggedDays * 100;

            string pattern;

            if (percentageBelow >= 70)
            {
                pattern = "Frequently below target";
            }
            else if (percentageBelow >= 30)
            {
                pattern = "Occasionally below target";
            }
            else
            {
                pattern = "Generally adequate";
            }

            return new PatternDto
            {
                Nutrient = requirement.Nutrient,
                DaysBelowTarget = daysBelowTarget,
                Pattern = pattern
            };
        }
    }
}