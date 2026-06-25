namespace Pathya.Api.DTOs
{
    public class FoodHistoryDto
    {
        public DateOnly Date { get; set; }

        public string Food { get; set; } = "";

        public decimal Quantity { get; set; }

        public decimal WeightInGrams { get; set; }
    }
}