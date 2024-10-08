﻿using MovieRental.Models.DTOs;

namespace MovieRental.Services.IServices
{
    public interface IRentalService
    {
        Task<IEnumerable<RentalDTO>> GetAllRentalsAsync();
        Task<RentalDTO> GetRentalByIdAsync(int id);
        Task RentMovieAsync(int movieId, RentalDTO rentalDTO);
        Task ReturnMovieAsync(int id);
        Task DeleteRentalAsync(int id);
        Task UpdateRentalAsync(int id, RentalDTO rentalDTO);
    }
}
