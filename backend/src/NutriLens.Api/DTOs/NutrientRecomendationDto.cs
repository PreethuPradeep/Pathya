namespace Pathya.Api.DTOs
{
    public class NutrientRecomendationDto
    {
        public string Nutrient { get; set; } = string.Empty;

        public decimal Remaining { get; set; }

        public List<string> Foods { get; set; }
            = new();
    }
}
