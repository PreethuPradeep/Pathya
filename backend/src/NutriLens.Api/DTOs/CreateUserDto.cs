namespace Pathya.Api.DTOs
{
    public class CreateUserDto
    {
        public DateOnly DateOfBirth { get; set; }

        public string Gender { get; set; } = string.Empty;

        public bool IsPregnant { get; set; }

        public bool IsBreastfeeding { get; set; }

        public decimal HeightCm { get; set; }

        public decimal WeightKg { get; set; }

        public string ActivityLevel { get; set; } = string.Empty;
    }
}