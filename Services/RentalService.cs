using MovieRental.Data.Repos.IRepos;
using MovieRental.Models;
using MovieRental.Models.DTOs;
using MovieRental.Services.IServices;

namespace MovieRental.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }
        public async Task DeleteRentalAsync(int rentalId)
        {
            await _rentalRepository.DeleteRentalAsync(rentalId);
        }

        public async Task<IEnumerable<RentalDTO>> GetAllRentalsAsync()
        {
            var rentalsList = await _rentalRepository.GetAllRentalsAsync();

            return rentalsList.Select(r => new RentalDTO
            {
                FK_MovieId = r.FK_MovieId,
                FK_UserId = r.FK_UserId,
                RentalDate = r.RentalDate,
                ReturnDate = r.ReturnDate
            }).ToList();
        }

        public async Task<RentalDTO> GetRentalByIdAsync(int rentalId)
        {
            var getRental = await _rentalRepository.GetRentalByIdAsync(rentalId);

            if (getRental==null)
            {
                return null;
            }

            return new RentalDTO
            {
                RentalDate = getRental.RentalDate,
                ReturnDate = getRental.ReturnDate,
                FK_MovieId = getRental.FK_MovieId,
                FK_UserId = getRental.FK_UserId
            };
        }

        public async Task RentMovieAsync(RentalDTO rentalDTO)
        {
            var existingRental = await _rentalRepository.GetRentalByIdAsync(rentalDTO.FK_MovieId);
            if (existingRental != null && existingRental.ReturnDate == null)
            {
                throw new InvalidOperationException("The movie is already rented out");
            }

            var rental = new Rental
            {
                FK_MovieId = rentalDTO.FK_MovieId,
                FK_UserId = rentalDTO.FK_UserId,
                RentalDate = DateTime.Now,
                ReturnDate = null
            };

            await _rentalRepository.AddRentalAsync(rental);
        }

        public async Task ReturnMovieAsync(int rentalId)
        {
            var rental = await _rentalRepository.GetRentalByIdAsync(rentalId);

            if (rental.ReturnDate != null)
            {
                throw new Exception("This movie has already been returned");
            }

            rental.ReturnDate = DateTime.Now;

            await _rentalRepository.UpdateRentalAsync(rental);
        }

        public async Task UpdateRentalAsync(int rentalId, RentalDTO rentalDTO)
        {
            var rental = await _rentalRepository.GetRentalByIdAsync(rentalId);

            if (rental == null)
            {
                throw new Exception($"Rental with id {rentalId} not found");
            }

            rental.RentalDate = rentalDTO.RentalDate;
            rental.ReturnDate = rentalDTO.ReturnDate;
            rental.FK_MovieId = rentalDTO.FK_MovieId;
            rental.FK_UserId = rentalDTO.FK_UserId;

            await _rentalRepository.UpdateRentalAsync(rental);
        }
    }
}
