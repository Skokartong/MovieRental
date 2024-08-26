using Microsoft.EntityFrameworkCore;
using MovieRental.Data.Repos.IRepos;
using MovieRental.Models;

namespace MovieRental.Data.Repos
{
    public class RentalRepository : IRentalRepository
    {
        private readonly MovieRentalContext _context;

        public RentalRepository(MovieRentalContext context)
        {
            _context = context;
        }
        public async Task AddRentalAsync(Rental rental)
        {
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRentalAsync(int rentalId)
        {
            var deleteRental = await _context.Rentals.FindAsync(rentalId);

            if (deleteRental!=null)
            {
                _context.Rentals.Remove(deleteRental);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            var rentalsList = await _context.Rentals.ToListAsync();
            return rentalsList;
        }

        public async Task<Rental> GetRentalByIdAsync(int movieId)
        {
            var rentedMovie = await _context.Rentals
                        .FirstOrDefaultAsync(r => r.FK_MovieId == movieId && r.ReturnDate == null);
            return rentedMovie;
        }

        public async Task UpdateRentalAsync(Rental rental)
        {
            _context.Rentals.Update(rental);
            await _context.SaveChangesAsync();
        }
    }
}
