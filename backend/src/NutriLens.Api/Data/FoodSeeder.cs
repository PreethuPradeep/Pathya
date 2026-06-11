using NutriLens.Api.Entities;

namespace NutriLens.Api.Data
{
    public class FoodSeeder
    {
        public static List<Food> GetFoods()
        {
            return new()
            {
                new Food
                {
                    Name = "Egg",
                    StandardWeightInGrams = 50
                },

                new Food
                {
                    Name = "Banana",
                    StandardWeightInGrams = 118
                },

                new Food
                {
                    Name = "Idli",
                    StandardWeightInGrams = 40
                },

                new Food
                {
                    Name = "Rice",
                    StandardWeightInGrams = 100
                },

                new Food
                {
                    Name = "Milk",
                    StandardWeightInGrams = 100
                }
            };
        }
    }
}
