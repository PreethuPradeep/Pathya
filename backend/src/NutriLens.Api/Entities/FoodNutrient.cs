namespace NutriLens.Api.Entities
{
    public class FoodNutrient
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int NutrientId { get; set; }
        public Nutrient Nutrient { get; set; } = null!;
        public decimal Amount { get; set; }
    }
}