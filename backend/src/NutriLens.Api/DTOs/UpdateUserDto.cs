namespace Pathya.Api.DTOs
{
    public class UpdateUserDto
    {
        public DateOnly DateOfBirth { get; set; }

        public string Gender { get; set; } = "";

        public bool IsPregnant { get; set; }

        public bool IsBreastfeeding { get; set; }

        public decimal HeightCm { get; set; }

        public decimal WeightKg { get; set; }

        public string ActivityLevel { get; set; } = "";
    }
}