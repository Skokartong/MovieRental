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

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var getUser = await _userRepository.GetUserById(id);

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

        public async Task UpdateUserAsync(int id, UserDTO userDTO)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.Name = userDTO.Name;
            user.Email = userDTO.Email;
            user.Address = userDTO.Address;

            await _userRepository.UpdateUserAsync(user);
        }
    }
}
