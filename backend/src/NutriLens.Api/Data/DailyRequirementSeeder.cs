using NutriLens.Api.Entities;

namespace NutriLens.Api.Data
{
    public static class DailyRequirementSeeder
    {
        public static List<DailyRequirement> GetRequirements()
        {
            return new()
            {
                new DailyRequirement
            {
                MinAge = 19,
                MaxAge = 50,
                Gender = "Male",
                IsPregnant = false,
                IsBreastFeeding = false,
                NutrientId = 1,
                RequiredAmount = 56
            },

            new DailyRequirement
            {
                MinAge = 19,
                MaxAge = 50,
                Gender = "Female",
                IsPregnant = false,
                IsBreastFeeding = false,
                NutrientId = 1,
                RequiredAmount = 46
            },

            new DailyRequirement
            {
                MinAge = 19,
                MaxAge = 50,
                Gender = "Male",
                IsPregnant = false,
                IsBreastFeeding = false,
                NutrientId = 2,
                RequiredAmount = 8
            },

            new DailyRequirement
            {
                MinAge = 19,
                MaxAge = 50,
                Gender = "Female",
                IsPregnant = false,
                IsBreastFeeding = false,
                NutrientId = 2,
                RequiredAmount = 18
            },

            new DailyRequirement
            {
                MinAge = 19,
                MaxAge = 50,
                Gender = "Female",
                IsPregnant = true,
                IsBreastFeeding = false,
                NutrientId = 2,
                RequiredAmount = 27
            }
            };
        }
    }
}
