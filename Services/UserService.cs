using MovieRental.Data.Repos.IRepos;
using MovieRental.Models;
using MovieRental.Models.DTOs;
using MovieRental.Services.IServices;

namespace MovieRental.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var usersList = await _userRepository.GetAllUsersAsync();
            return usersList.Select(u => new UserDTO
            {
                Name = u.Name,
                Email = u.Email,
                Address = u.Address
            }).ToList();
        }
        public async Task AddUserAsync(UserDTO user)
        {
            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address
            };

            await _userRepository.AddUserAsync(newUser);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var getUser = await _userRepository.GetUserById(userId);

            if(getUser == null)
            {
                return null;
            }

            return new UserDTO
            {
                Name = getUser.Name,
                Email = getUser.Email,
                Address = getUser.Address
            };
        }

        public async Task UpdateUserAsync(UserDTO user)
        {
            var updatedUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address
            };

            await _userRepository.UpdateUserAsync(updatedUser);
        }
    }
}
