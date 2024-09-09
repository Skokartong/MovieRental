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

        public async Task DeleteRentalAsync(int id)
        {
            var deleteRental = await _context.Rentals.FindAsync(id);

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

        public async Task<Rental> GetRentalByIdAsync(int id)
        {
            var rental = await _context.Rentals
                        .FindAsync(id);
            return rental;
        }

        public async Task UpdateRentalAsync(Rental rental)
        {
            _context.Rentals.Update(rental);
            await _context.SaveChangesAsync();
        }
    }
}
