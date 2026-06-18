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
        },

        new DailyRequirement
        {
            MinAge = 19,
            MaxAge = 50,
            Gender = "Male",
            IsPregnant = false,
            IsBreastFeeding = false,
            NutrientId = 4, // Vitamin D
            RequiredAmount = 600
        },

        new DailyRequirement
        {
            MinAge = 19,
            MaxAge = 50,
            Gender = "Male",
            IsPregnant = false,
            IsBreastFeeding = false,
            NutrientId = 5, // Vitamin B12
            RequiredAmount = 2.4m
        },

        new DailyRequirement
        {
            MinAge = 19,
            MaxAge = 50,
            Gender = "Male",
            IsPregnant = false,
            IsBreastFeeding = false,
            NutrientId = 7, // Folate
            RequiredAmount = 400
        },

        new DailyRequirement
        {
            MinAge = 19,
            MaxAge = 50,
            Gender = "Male",
            IsPregnant = false,
            IsBreastFeeding = false,
            NutrientId = 8, // Magnesium
            RequiredAmount = 420
        },

        new DailyRequirement
        {
            MinAge = 19,
            MaxAge = 50,
            Gender = "Male",
            IsPregnant = false,
            IsBreastFeeding = false,
            NutrientId = 9, // Zinc
            RequiredAmount = 11
        },

        new DailyRequirement
        {
            MinAge = 19,
            MaxAge = 50,
            Gender = "Female",
            IsPregnant = false,
            IsBreastFeeding = false,
            NutrientId = 4, // Vitamin D
            RequiredAmount = 600
        },

        new DailyRequirement
        {
            MinAge = 19,
            MaxAge = 50,
            Gender = "Female",
            IsPregnant = false,
            IsBreastFeeding = false,
            NutrientId = 5, // Vitamin B12
            RequiredAmount = 2.4m
        },

        new DailyRequirement
        {
            MinAge = 19,
            MaxAge = 50,
            Gender = "Female",
            IsPregnant = false,
            IsBreastFeeding = false,
            NutrientId = 7, // Folate
            RequiredAmount = 400
        },

        new DailyRequirement
        {
            MinAge = 19,
            MaxAge = 50,
            Gender = "Female",
            IsPregnant = false,
            IsBreastFeeding = false,
            NutrientId = 8, // Magnesium
            RequiredAmount = 320
        },

        new DailyRequirement
        {
            MinAge = 19,
            MaxAge = 50,
            Gender = "Female",
            IsPregnant = false,
            IsBreastFeeding = false,
            NutrientId = 9, // Zinc
            RequiredAmount = 8
        },

        new DailyRequirement
        {
            MinAge = 19,
            MaxAge = 50,
            Gender = "Female",
            IsPregnant = true,
            IsBreastFeeding = false,
            NutrientId = 4, // Vitamin D
            RequiredAmount = 600
        },

        new DailyRequirement
        {
            MinAge = 19,
            MaxAge = 50,
            Gender = "Female",
            IsPregnant = true,
            IsBreastFeeding = false,
            NutrientId = 5, // Vitamin B12
            RequiredAmount = 2.6m
        },

        new DailyRequirement
        {
            MinAge = 19,
            MaxAge = 50,
            Gender = "Female",
            IsPregnant = true,
            IsBreastFeeding = false,
            NutrientId = 7, // Folate
            RequiredAmount = 600
        },

        new DailyRequirement
        {
            MinAge = 19,
            MaxAge = 50,
            Gender = "Female",
            IsPregnant = true,
            IsBreastFeeding = false,
            NutrientId = 8, // Magnesium
            RequiredAmount = 350
        },

        new DailyRequirement
        {
            MinAge = 19,
            MaxAge = 50,
            Gender = "Female",
            IsPregnant = true,
            IsBreastFeeding = false,
            NutrientId = 9, // Zinc
            RequiredAmount = 11
        },
            };
        }
    }
}
