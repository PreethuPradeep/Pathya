using Microsoft.EntityFrameworkCore;
using NutriLens.Api.Data;
using NutriLens.Api.DTOs;

namespace NutriLens.Api.Services
{
    public class RequirementService : IRequirementService
    {
        private readonly ApplicationDbContext Context;
        public RequirementService(ApplicationDbContext context)
        {
            Context = context;
        }
        public async Task<List<NutrientRequirementDto>> GetRequirementsAsync(int userId)
        {
            var user = await Context.Users.FirstOrDefaultAsync(a => a.Id == userId);
            if (user is null) { return new List<NutrientRequirementDto>(); }
            var age = CalculateAge(user.DateOfBirth);

            var requirements = await Context.DailyRequirements
                .Include(x => x.Nutrient)
                .Where(x =>
                                age >= x.MinAge &&
                                age <= x.MaxAge &&
                                x.Gender == user.Gender &&
                                x.IsPregnant == user.IsPregnant &&
                                x.IsBreastFeeding == user.IsBreastfeeding)
                .Select(x => new NutrientRequirementDto
                {
                    Nutrient = x.Nutrient.Name,
                    RequiredAmount = x.RequiredAmount,
                    Unit = x.Nutrient.Unit
                })
                .ToListAsync();
            return requirements;
        }
        private static int CalculateAge(DateOnly DateOfBirth)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
