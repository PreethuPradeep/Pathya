namespace Pathya.Api.DTOs
{
    public class NutritionHistoryDto
    {
        public DateOnly Date { get; set; }

        public List<ConsumeNutrientDto> Nutrients { get; set; }
            = new();
    }
}