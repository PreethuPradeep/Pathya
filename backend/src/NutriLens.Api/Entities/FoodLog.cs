namespace Pathya.Api.Entities
{
    public class FoodLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateOnly Date { get; set; }
        public ICollection<FoodLogItem> Items { get; set; } = new List<FoodLogItem>();
    }
}
