using Pathya.Api.Entities;
using System.Text.Json;

namespace Pathya.Api.Data
{
    public static class NutritionJsonImporter
    {
        public static List<FoodNutritionSeed> LoadFoods()
        {
            var json = File.ReadAllText("SeedData/nutrition.json");

            Console.WriteLine(json);

            var foods = JsonSerializer.Deserialize<List<FoodNutritionSeed>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            Console.WriteLine($"Count: {foods?.Count}");

            Console.WriteLine(
                JsonSerializer.Serialize(
                    foods,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));

            return foods ?? new();
            //return JsonSerializer.Deserialize<List<FoodNutritionSeed>>(json) ?? new();
        }
    
    public static List<Food>
    GetFoods()
        {
            var data = LoadFoods();

            return data
                .Select(x =>
                    new Food
                    {
                        Name = x.Food,
                        StandardWeightInGrams = 100
                    })
                .ToList();
        }
        public static List<FoodNutrient>
    GetFoodNutrients(
        List<Food> foods)
        {
            var data = LoadFoods();

            var result =
                new List<FoodNutrient>();

            foreach (var item in data)
            {
                var food =
                    foods.First(
                        x => x.Name == item.Food);

                result.Add(
                    new FoodNutrient
                    {
                        FoodId = food.Id,
                        NutrientId = 1,
                        AmountPer100g = item.Protein
                    });

                result.Add(
                    new FoodNutrient
                    {
                        FoodId = food.Id,
                        NutrientId = 2,
                        AmountPer100g = item.Iron
                    });

                result.Add(
                    new FoodNutrient
                    {
                        FoodId = food.Id,
                        NutrientId = 3,
                        AmountPer100g = item.Calcium
                    });

                result.Add(
                    new FoodNutrient
                    {
                        FoodId = food.Id,
                        NutrientId = 6,
                        AmountPer100g = item.Fiber
                    });
            }

            return result;
        }
    }
}
