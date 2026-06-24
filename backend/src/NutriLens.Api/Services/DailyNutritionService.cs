using Microsoft.EntityFrameworkCore;
using Pathya.Api.Data;
using Pathya.Api.DTOs;
using Pathya.Api.Entities;

namespace Pathya.Api.Services
{
    public class DailyNutritionService : IDailyNutritionService
    {
        private readonly ApplicationDbContext _context;

        public DailyNutritionService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConsumeNutrientDto>> GetDailyNutrientsAsync(int userId, DateOnly date)
        {
            var range =
                await GetDailyNutrientsForRangeAsync(userId, date, date);

            return range.TryGetValue(date, out var nutrients)
                ? nutrients
                : new List<ConsumeNutrientDto>();
        }

        public async Task<IReadOnlyDictionary<DateOnly, List<ConsumeNutrientDto>>>
            GetDailyNutrientsForRangeAsync(
                int userId,
                DateOnly startDate,
                DateOnly endDate)
        {
            var foodItems = await _context.FoodLogItems
                .AsNoTracking()
                .Include(x => x.FoodLog)
                .Where(x =>
                    x.FoodLog.UserId == userId &&
                    x.FoodLog.Date >= startDate &&
                    x.FoodLog.Date <= endDate)
                .ToListAsync();

            if (foodItems.Count == 0)
            {
                return new Dictionary<DateOnly, List<ConsumeNutrientDto>>();
            }

            var foodIds = foodItems
                .Select(x => x.FoodId)
                .Distinct()
                .ToList();

            var foodNutrients = await _context.FoodNutrients
                .AsNoTracking()
                .Include(x => x.Nutrient)
                .Where(x => foodIds.Contains(x.FoodId))
                .ToListAsync();

            return BuildDailyNutritionByDate(foodItems, foodNutrients);
        }

        internal static Dictionary<DateOnly, List<ConsumeNutrientDto>>
            BuildDailyNutritionByDate(
                IReadOnlyList<FoodLogItem> foodItems,
                IReadOnlyList<FoodNutrient> foodNutrients)
        {
            var nutrientsByFoodId = foodNutrients
                .GroupBy(x => x.FoodId)
                .ToDictionary(
                    g => g.Key,
                    g => (IReadOnlyList<FoodNutrient>)g.ToList());

            var nutrientMetadata = foodNutrients
                .GroupBy(x => x.NutrientId)
                .ToDictionary(
                    g => g.Key,
                    g => g.First().Nutrient);

            var totalsByDate =
                new Dictionary<DateOnly, Dictionary<int, decimal>>();

            foreach (var item in foodItems)
            {
                if (!nutrientsByFoodId.TryGetValue(item.FoodId, out var nutrientsForFood))
                {
                    continue;
                }

                var date = item.FoodLog.Date;

                if (!totalsByDate.TryGetValue(date, out var totals))
                {
                    totals = new Dictionary<int, decimal>();
                    totalsByDate[date] = totals;
                }

                foreach (var nutrient in nutrientsForFood)
                {
                    var amount =
                        item.WeightInGrams *
                        nutrient.AmountPer100g /
                        100m;

                    if (!totals.ContainsKey(nutrient.NutrientId))
                    {
                        totals[nutrient.NutrientId] = 0;
                    }

                    totals[nutrient.NutrientId] += amount;
                }
            }

            var result =
                new Dictionary<DateOnly, List<ConsumeNutrientDto>>();

            foreach (var (date, totals) in totalsByDate)
            {
                var dtos = new List<ConsumeNutrientDto>();

                foreach (var total in totals)
                {
                    var nutrient = nutrientMetadata[total.Key];

                    dtos.Add(
                        new ConsumeNutrientDto
                        {
                            Nutrient = nutrient.Name,
                            Amount = total.Value,
                            Unit = nutrient.Unit
                        });
                }

                result[date] = dtos;
            }

            return result;
        }
    }
}
