using Pathya.Api.Entities;

namespace Pathya.Api.Data
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
            },
            new DailyRequirement
{
    MinAge = 19,
    MaxAge = 50,
    Gender = "Male",
    IsPregnant = false,
    IsBreastFeeding = false,
    NutrientId = 3, // Calcium
    RequiredAmount = 1000
},

new DailyRequirement
{
    MinAge = 19,
    MaxAge = 50,
    Gender = "Female",
    IsPregnant = false,
    IsBreastFeeding = false,
    NutrientId = 3,
    RequiredAmount = 1000
},

new DailyRequirement
{
    MinAge = 19,
    MaxAge = 50,
    Gender = "Female",
    IsPregnant = true,
    IsBreastFeeding = false,
    NutrientId = 3,
    RequiredAmount = 1000
},

new DailyRequirement
{
    MinAge = 19,
    MaxAge = 50,
    Gender = "Male",
    IsPregnant = false,
    IsBreastFeeding = false,
    NutrientId = 6, // Fiber
    RequiredAmount = 30
},

new DailyRequirement
{
    MinAge = 19,
    MaxAge = 50,
    Gender = "Female",
    IsPregnant = false,
    IsBreastFeeding = false,
    NutrientId = 6,
    RequiredAmount = 25
},

new DailyRequirement
{
    MinAge = 19,
    MaxAge = 50,
    Gender = "Female",
    IsPregnant = true,
    IsBreastFeeding = false,
    NutrientId = 6,
    RequiredAmount = 28
},

new DailyRequirement
{
    MinAge = 19,
    MaxAge = 50,
    Gender = "Female",
    IsPregnant = true,
    IsBreastFeeding = false,
    NutrientId = 1, // Protein
    RequiredAmount = 71
}
            };
        }
    }
}
