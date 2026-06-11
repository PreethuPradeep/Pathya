namespace Pathya.Api.Entities
{
    public class FoodNutritionSeed
    {
        public string Food { get; set; } = string.Empty;

        public decimal Protein { get; set; }

        public decimal Iron { get; set; }

        public decimal Calcium { get; set; }

        public decimal Fiber { get; set; }
    }
}
