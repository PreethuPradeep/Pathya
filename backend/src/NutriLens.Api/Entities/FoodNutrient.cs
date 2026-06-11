namespace Pathya.Api.Entities
{
    public class FoodNutrient
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; } = null!;
        public int NutrientId { get; set; }
        public Nutrient Nutrient { get; set; } = null!;
        public decimal AmountPer100g { get; set; }
    }
}