namespace Pathya.Api.Entities
{
    public class FoodLogItem
    {
        public int Id { get; set; }
        public int FoodLogId { get; set; }
        public FoodLog FoodLog { get; set; } = null!;
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public decimal Quantity { get; set; }
        public decimal WeightInGrams { get; set; }
    }
}