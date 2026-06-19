namespace Pathya.Api.DTOs
{
    public class NutrientTrendDto
    {
        public string Nutrient { get; set; } = "";

        public decimal PreviousWeekAverage { get; set; }

        public decimal CurrentWeekAverage { get; set; }

        public decimal ChangePercent { get; set; }

        public string Trend { get; set; } = "";
        public string Insight { get; set; } = "";
    }
}
