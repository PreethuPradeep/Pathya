using NutriLens.Api.Entities;

namespace NutriLens.Api.Data
{
    public static class NutrientSeeder
    {
        public static List<Nutrient> GetNutrients()
        {
            return new()
            {
                new Nutrient {Name = "Protein", Unit = "g"},
                new Nutrient { Name = "Iron", Unit = "mg" },
                new Nutrient { Name = "Calcium", Unit = "mg" },
                new Nutrient { Name = "Vitamin D", Unit = "IU" },
                new Nutrient { Name = "Vitamin B12", Unit = "mcg" },
                new Nutrient { Name = "Fiber", Unit = "g" }
            };
        }
    }
}
