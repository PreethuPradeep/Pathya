namespace Pathya.Api.DTOs
{
    public class CreateFoodLogDto
    {
        public int UserId { get; set; }
        public int FoodId { get; set; }
        public decimal Quantity { get; set; }
    }
}
