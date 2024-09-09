using MovieRental.Models;
using MovieRental.Models.DTOs;

namespace MovieRental.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int userId);
        Task AddUserAsync(UserDTO user);
        Task UpdateUserAsync(int userId, UserDTO user);
        Task DeleteUserAsync(int userId);
    }
}
