using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public interface IRequirementService
    {
        Task<List<NutrientRequirementDto>> GetRequirementsAsync(int userId);
    }
}
