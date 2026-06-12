using Pathya.Api.Entities;

namespace Pathya.Api.Data
{
    public static class NutrientImpactSeeder
    {
        public static List<NutrientImpact> GetImpacts()
        {
            return new()
            {
                new NutrientImpact
                {
                    NutrientName = "Iron",
                    Supports = "Energy, oxygen transport and focus",
                    RecommendationText =
                    "Consider adding legumes and iron-rich foods."
                },
                new NutrientImpact
                {
                    NutrientName = "Protein",
                    Supports =
                    "Muscle maintenance, recovery and healthy aging",

                    RecommendationText =
                    "Include more protein-rich foods throughout the day."
                },

                new NutrientImpact
                {
                    NutrientName = "Calcium",
                    Supports =
                    "Bone health and healthy aging",

                    RecommendationText =
                    "Add calcium-rich foods such as milk, curd or ragi."
                },

                new NutrientImpact
                {
                    NutrientName = "Fiber",
                    Supports =
                    "Digestive and metabolic health",

                    RecommendationText =
                    "Increase fruits, vegetables and legumes."
                }
            };
        }
    }
}
