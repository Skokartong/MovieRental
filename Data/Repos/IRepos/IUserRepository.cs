using MovieRental.Models;
using MovieRental.Models.DTOs;

namespace MovieRental.Data.Repos.IRepos
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserById(int userId);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
    }
}
