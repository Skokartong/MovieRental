using MovieRental.Models.DTOs;

namespace MovieRental.Services.IServices
{
    public interface IRentalService
    {
        Task<IEnumerable<RentalDTO>> GetAllRentalsAsync();
        Task<RentalDTO> GetRentalByIdAsync(int rentalId);
        Task RentMovieAsync(RentalDTO rental);
        Task ReturnMovieAsync(int rentalId);
        Task DeleteRentalAsync(int rentalId);
        Task UpdateRentalAsync(int rentalId, RentalDTO rentalDTO);
    }
}
