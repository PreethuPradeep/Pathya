namespace Pathya.Api.DTOs
{
    public class NutritionCoverageDto
    {
        public int TrackedNutrients { get; set; }

        public int MetNutrients { get; set; }

        public decimal CoveragePercentage { get; set; }

        public List<string> MissingNutrients { get; set; } = [];
    }
}
