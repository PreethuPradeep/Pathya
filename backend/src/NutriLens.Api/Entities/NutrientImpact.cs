namespace Pathya.Api.Entities
{
    public class NutrientImpact
    {
        public int Id { get; set; }

        public string NutrientName { get; set; } = string.Empty;

        public string Supports { get; set; } = string.Empty;

        public string RecommendationText { get; set; } = string.Empty;
    }
}
