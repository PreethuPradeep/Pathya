namespace Pathya.Api.DTOs
{
    public class NutrientAnalysisDto
    {
        public string Nutrient { get; set; } = string.Empty;

        public decimal Required { get; set; }

        public decimal Consumed { get; set; }

        public decimal Remaining { get; set; }

        public decimal PercentageMet { get; set; }

        public string Unit { get; set; } = string.Empty;
    }
}
