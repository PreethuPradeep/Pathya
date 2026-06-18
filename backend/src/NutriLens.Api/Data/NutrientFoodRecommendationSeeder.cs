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
                    NutrientId = NutrientIds.Protein,
                    FoodName = "Rajma",
                    Reason = "Rich source of iron"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Protein,
                    FoodName = "Eggs",
                    Reason = "Rich Source of protein"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Iron,
                    FoodName = "Chickpeas",
                    Reason = "Rich source of iron"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Iron,
                    FoodName = "Egg curry",
                    Reason = "Rich source of iron"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Iron,
                    FoodName = "Spinach",
                    Reason = "Rich source of iron"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Protein,
                    FoodName = "Paneer",
                    Reason = "Rich source of protein"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Protein,
                    FoodName = "Chicken Breast",
                    Reason = "Rich source of protein"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Protein,
                    FoodName = "Soy Chunks",
                    Reason = "Rich source of protein"
                },

                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Calcium,
                    FoodName = "Milk",
                    Reason = "Rich source of calcium"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Calcium,
                    FoodName = "Curd",
                    Reason = "Rich source of calcium"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Calcium,
                    FoodName = "Ragi",
                    Reason = "Rich source of calcium"
                },

                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.VitaminD,
                    FoodName = "Fish",
                    Reason = "Rich source of vitamin D"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.VitaminD,
                    FoodName = "Egg",
                    Reason = "Contains vitamin D"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.VitaminD,
                    FoodName = "Milk",
                    Reason = "Provides vitamin D"
                },

                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.VitaminB12,
                    FoodName = "Fish",
                    Reason = "Rich source of vitamin B12"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.VitaminB12,
                    FoodName = "Egg",
                    Reason = "Contains vitamin B12"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.VitaminB12,
                    FoodName = "Paneer",
                    Reason = "Provides vitamin B12"
                },

                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Folate,
                    FoodName = "Chickpeas",
                    Reason = "Rich source of folate"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Folate,
                    FoodName = "Rajma",
                    Reason = "Rich source of folate"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Folate,
                    FoodName = "Spinach",
                    Reason = "Rich source of folate"
                },

                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Magnesium,
                    FoodName = "Soy Chunks",
                    Reason = "Rich source of magnesium"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Magnesium,
                    FoodName = "Ragi",
                    Reason = "Good source of magnesium"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Magnesium,
                    FoodName = "Groundnuts",
                    Reason = "Good source of magnesium"
                },

                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Zinc,
                    FoodName = "Soy Chunks",
                    Reason = "Rich source of zinc"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Zinc,
                    FoodName = "Chickpeas",
                    Reason = "Good source of zinc"
                },
                new NutrientFoodRecomendation
                {
                    NutrientId = NutrientIds.Zinc,
                    FoodName = "Paneer",
                    Reason = "Provides zinc"
                }
            };
        }
    }
}
