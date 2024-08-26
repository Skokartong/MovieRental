using MovieRental.Models.DTOs;

namespace MovieRental.Services.IServices
{
    public interface IRentalService
    {
        Task<IEnumerable<RentalDTO>> GetAllRentalsAsync();
        Task<RentalDTO> GetRentalByIdAsync(int rentalId);
        Task RentMovieAsync(RentalDTO rental);
        Task ReturnMovieAsync(RentalDTO rental);
        Task DeleteRentalAsync(int rentalId);
    }
}
