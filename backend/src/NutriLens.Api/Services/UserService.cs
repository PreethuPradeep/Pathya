using Microsoft.EntityFrameworkCore;
using Pathya.Api.Data;
using Pathya.Api.DTOs;
using Pathya.Api.Entities;

namespace Pathya.Api.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateUserAsync(
            CreateUserDto request)
        {
            var user = new User
            {
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                IsPregnant = request.IsPregnant,
                IsBreastfeeding = request.IsBreastfeeding,
                HeightCm = request.HeightCm,
                WeightKg = request.WeightKg,
                ActivityLevel = request.ActivityLevel
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<UserDto?> GetUserAsync(
            int userId)
        {
            return await _context.Users
                .Where(x => x.Id == userId)
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    DateOfBirth = x.DateOfBirth,
                    Gender = x.Gender,
                    IsPregnant = x.IsPregnant,
                    IsBreastfeeding = x.IsBreastfeeding,
                    HeightCm = x.HeightCm,
                    WeightKg = x.WeightKg,
                    ActivityLevel = x.ActivityLevel
                })
                .FirstOrDefaultAsync();
        }
    }
}