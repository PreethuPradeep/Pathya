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
                },

                new NutrientImpact
                {
                    NutrientName = "Vitamin D",
                    Supports = "Bone health, immunity and muscle function",
                    RecommendationText =
                        "Consider sunlight exposure and vitamin D rich foods."
                },

                new NutrientImpact
                {
                    NutrientName = "Vitamin B12",
                    Supports = "Nervous system health and energy metabolism",
                    RecommendationText =
                        "Include animal foods or fortified foods regularly."
                },

                new NutrientImpact
                {
                    NutrientName = "Folate",
                    Supports = "Cell growth and healthy blood formation",
                    RecommendationText =
                        "Increase legumes and leafy vegetables."
                },

                new NutrientImpact
                {
                    NutrientName = "Magnesium",
                    Supports = "Muscle function, nerve function and energy production",
                    RecommendationText =
                        "Add nuts, legumes and whole grains."
                },

                new NutrientImpact
                {
                    NutrientName = "Zinc",
                    Supports = "Immune function and wound healing",
                    RecommendationText =
                        "Include legumes, dairy and protein-rich foods."
                }
            };
        }
    }
}
