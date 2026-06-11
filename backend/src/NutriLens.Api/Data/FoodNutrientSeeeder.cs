using NutriLens.Api.Entities;
using System.Reflection.Metadata.Ecma335;

namespace NutriLens.Api.Data
{
    public static class FoodNutrientSeeeder
    {
        public static List<FoodNutrient> GetFoodNutrients()
        {
            return new()
            {
                new FoodNutrient
                {
                    FoodId = 1,
                    NutrientId = 1,
                    AmountPer100g = 13m
                },
                new FoodNutrient
                {
                    FoodId = 1,
                    NutrientId = 2,
                    AmountPer100g = 1.8m
                },
                new FoodNutrient
                {
                    FoodId = 2,
                    NutrientId = 1,
                    AmountPer100g = 1.1m
                },
                new FoodNutrient
                {
                    FoodId = 2,
                    NutrientId = 6,
                    AmountPer100g = 2.6m
                },
                new FoodNutrient
                {
                    FoodId = 3,
                    NutrientId = 1,
                    AmountPer100g = 4m
                },
                new FoodNutrient
                {
                    FoodId = 3,
                    NutrientId = 2,
                    AmountPer100g = 0.3m
                }
            };
        }
    }
}
