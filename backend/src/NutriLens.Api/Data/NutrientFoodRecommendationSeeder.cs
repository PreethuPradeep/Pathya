using Pathya.Api.Entities;

namespace Pathya.Api.Data
{
    public static class NutrientFoodRecommendationSeeder
    {
        public static List<NutrientFoodRecomendation> GetNutrientFoodRecomendations()
        {
            return new()
            {
                new NutrientFoodRecomendation
                {
                    NutrientId = 2,
                    FoodName = "Rajma",
                    Reason = "Rich source of iron"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = 1,
                    FoodName = "Eggs",
                    Reason = "Rich Source of protein"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = 2,
                    FoodName = "Chickpeas",
                    Reason = "Rich source of iron"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = 2,
                    FoodName = "Egg curry",
                    Reason = "Rich source of iron"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = 2,
                    FoodName = "Spinach",
                    Reason = "Rich source of iron"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = 1,
                    FoodName = "Paneer",
                    Reason = "Rich source of protein"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = 1,
                    FoodName = "Chicken",
                    Reason = "Rich source of protein"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = 1,
                    FoodName = "Soy chunks",
                    Reason = "Rich source of protein"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = 3,
                    FoodName = "Milk",
                    Reason = "Rich source of calcium"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = 3,
                    FoodName = "Curd",
                    Reason = "Rich source of calcium"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = 3,
                    FoodName = "Ragi",
                    Reason = "Rich source of calcium"
                }
            };
        }
    }
}
