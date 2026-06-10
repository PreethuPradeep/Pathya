namespace NutriLens.Api.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public decimal HeightCm { get; set; }
        public decimal WeightKg { get; set; }
        public string ActivityLevel { get; set; } = string.Empty;
    }
}
