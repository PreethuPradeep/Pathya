namespace Pathya.Api.Entities
{
    public class DailyRequirement
    {
        public int Id { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public string Gender { get; set; } = string.Empty;
        public bool IsPregnant { get; set; }
        public bool IsBreastFeeding { get; set; }
        public int NutrientId { get; set; }
        public Nutrient Nutrient { get; set; } = null!;
        public decimal RequiredAmount { get; set; }
    }
}
