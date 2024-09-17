using MovieRental.Models;

namespace MovieRental.Data.Repos.IRepos
{
    public interface IRentalRepository
    {
        Task<IEnumerable<Rental>> GetAllRentalsAsync();
        Task<Rental> GetRentalByIdAsync(int id);
        Task AddRentalAsync(Rental rental);
        Task UpdateRentalAsync(Rental rental);
        Task<bool> IsMovieRentedAsync(int movieId);
        Task DeleteRentalAsync(int id);
    }
}
