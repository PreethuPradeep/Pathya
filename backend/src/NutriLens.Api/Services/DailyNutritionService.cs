using Microsoft.EntityFrameworkCore;
using Pathya.Api.Data;
using Pathya.Api.DTOs;

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
            var foodItems = await _context.FoodLogItems.Include(x => x.FoodLog)
                            .Include(x => x.Food).Where(x => x.FoodLog.UserId == userId && x.FoodLog.Date == date)
                            .ToListAsync();
            var nutrients = await _context.FoodNutrients.Include(x => x.Nutrient).ToListAsync();
            var totals = new Dictionary<int, decimal>();

            foreach( var item in foodItems)
            {
                var foodNutrients = nutrients.Where(x => x.FoodId == item.FoodId);
                foreach(var nutrient in foodNutrients)
                {
                    var amount = item.WeightInGrams * nutrient.AmountPer100g / 100m;
                    if (!totals.ContainsKey(nutrient.NutrientId))
                    {
                        totals[nutrient.NutrientId] = 0;
                    }
                    totals[nutrient.NutrientId] += amount;
                }
            }
            var result = new List<ConsumeNutrientDto>();
            foreach (var total in totals)
            {
                var nutrient =
                    nutrients
                        .First(x =>
                            x.NutrientId ==
                            total.Key)
                        .Nutrient;

                result.Add(
                    new ConsumeNutrientDto
                    {
                        Nutrient =
                            nutrient.Name,

                        Amount =
                            total.Value,

                        Unit =
                            nutrient.Unit
                    });
            }
            return result;
        }
    }
}
