namespace Pathya.Api.DTOs
{
    public class NutrientGapRecommendationDto
    {
        public string Nutrient { get; set; } = "";

        public decimal RemainingAmount { get; set; }

        public string Unit { get; set; } = "";
        public decimal PercentageMet { get; set; }

        public List<FoodGapRecommendationDto> Foods
        { get; set; } = [];
    }
}
