using Microsoft.EntityFrameworkCore;
using Pathya.Api.Data;
using Pathya.Api.DTOs;
using Pathya.Api.Entities;

namespace Pathya.Api.Services
{
    public class FoodLogService : IFoodLogService
    {
        private readonly ApplicationDbContext _context;
        private readonly IDailyNutritionService _dailyNutritionService;
        public FoodLogService(ApplicationDbContext context, IDailyNutritionService dailyNutritionService)
        {
            _context = context;
            _dailyNutritionService = dailyNutritionService;
        }
        public async Task AddFoodAsync(CreateFoodLogDto request)
        {
            var food = await _context.Foods.FirstOrDefaultAsync(
                x => x.Id == request.FoodId);
            if (food is null)
            {
                throw new Exception("Food not found");
            }
            var weight = food.StandardWeightInGrams * request.Quantity;
            var today = DateOnly.FromDateTime(DateTime.Today);
            var foodLog = await _context.FoodLogs.FirstOrDefaultAsync(
                x => x.UserId == request.UserId && x.Date == today);
            if (foodLog is null)
            {
                foodLog = new Entities.FoodLog
                {
                    UserId = request.UserId,
                    Date = today
                };
                _context.FoodLogs.Add(foodLog);
                await _context.SaveChangesAsync();
            }
            var item = new FoodLogItem
            {
                FoodLogId = foodLog.Id,
                FoodId = request.FoodId,
                Quantity = request.Quantity,
                WeightInGrams = Math.Round(weight,2)
            };
            _context.FoodLogItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ConsumeNutrientDto>> GetConsumedNutrientsAsync(int userId)
        {
            //var today = DateOnly.FromDateTime(DateTime.Today);
            //var result = await _context.FoodLogItems
            //    .Include(x => x.Food)
            //    .Include(x => x.FoodLog)
            //    .Where(x =>
            //        x.FoodLog.UserId == userId &&
            //        x.FoodLog.Date == today)
            //    .SelectMany(x =>
            //        _context.FoodNutrients.Where(f => f.FoodId == x.FoodId)
            //        .Select(f => new
            //        {
            //            f.NutrientId,
            //            NutrientName = f.Nutrient.Name,
            //            Unit = f.Nutrient.Unit,
            //            Amount = x.WeightInGrams * f.AmountPer100g / 100m
            //        }))
            //    .ToListAsync();
            //return result.GroupBy(x => new
            //{
            //    x.NutrientId,
            //    x.NutrientName,
            //    x.Unit
            //})
            //    .Select(x => new ConsumeNutrientDto
            //    {
            //        Nutrient = x.Key.NutrientName,
            //        Unit = x.Key.Unit,
            //        Amount = Math.Round(x.Sum(y => y.Amount),2)
            //    }).ToList();
            return await _dailyNutritionService.GetDailyNutrientsAsync(userId, DateOnly.FromDateTime(DateTime.Today));
        }
    }
}
