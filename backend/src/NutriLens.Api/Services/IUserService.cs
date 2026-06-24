using Pathya.Api.DTOs;

namespace Pathya.Api.Services
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(CreateUserDto request);

        Task<UserDto?> GetUserAsync(int userId);
    }
}
