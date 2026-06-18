namespace Pathya.Api.Entities
{
    public class FoodNutritionSeed
    {
        public string Food { get; set; } = string.Empty;

        public decimal Protein { get; set; }

        public decimal Iron { get; set; }

        public decimal Calcium { get; set; }

        public decimal Fiber { get; set; }
        public decimal VitaminD { get; set; }

        public decimal VitaminB12 { get; set; }

        public decimal Folate { get; set; }

        public decimal Magnesium { get; set; }

        public decimal Zinc { get; set; }
    }
}
