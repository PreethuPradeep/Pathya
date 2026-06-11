namespace Pathya.Api.Entities
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal StandardWeightInGrams { get; set; }
        public ICollection<FoodNutrient> FoodNutrients { get; set; } = new List<FoodNutrient>();
    }
}
