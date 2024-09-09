using MovieRental.Models;
using MovieRental.Models.DTOs;

namespace MovieRental.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task AddUserAsync(UserDTO userDTO);
        Task UpdateUserAsync(int id, UserDTO userDTO);
        Task DeleteUserAsync(int id);
    }
}
