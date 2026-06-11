namespace NutriLens.Api.DTOs
{
    public class NutrientRequirementDto
    {
        public string Nutrient { get; set; } = string.Empty;
        public decimal RequiredAmount { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
