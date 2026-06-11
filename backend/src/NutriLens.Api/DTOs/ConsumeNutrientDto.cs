
namespace Pathya.Api.DTOs
{
    public class ConsumeNutrientDto
    {
        public string Nutrient { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
