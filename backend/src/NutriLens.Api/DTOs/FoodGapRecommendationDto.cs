namespace Pathya.Api.DTOs
{
    public class FoodGapRecommendationDto
    {
        public string Food { get; set; } = "";

        public decimal GramsNeeded { get; set; }

        public string Reason { get; set; } = "";
    }
}
