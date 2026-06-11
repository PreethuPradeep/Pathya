namespace Pathya.Api.DTOs
{
    public class NutrientConsumption
    {
        public int NutrientId { get; set; }
        public string NutrientName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
