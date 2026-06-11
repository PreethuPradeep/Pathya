using NutriLens.Api.DTOs;

namespace NutriLens.Api.Services
{
    public interface IRequirementService
    {
        Task<List<NutrientRequirementDto>> GetRequirementsAsync(int userId);
    }
}
