namespace Pathya.Api.Entities
{
    public class NutrientFoodRecomendation
    {
        public int Id { get; set; }

        public int NutrientId { get; set; }

        public Nutrient Nutrient { get; set; } = null!;

        public string FoodName { get; set; } = string.Empty;

        public string Reason { get; set; } = string.Empty;
    }
}
