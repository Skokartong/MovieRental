using MovieRental.Models.DTOs;

namespace MovieRental.Services.IServices
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetAllMoviesAsync();
        Task<MovieDTO?> GetMovieByIdAsync(int id);
        Task AddMovieAsync(MovieDTO movieDTO);
        Task DeleteMovieAsync(int id);
        Task<bool> UpdateMovieAsync(MovieDTO movieDTO);
        Task<IEnumerable<MovieDTO>> SearchMoviesByGenreAsync(string genre);
        Task<MovieDTO> SearchMovieByNameAsync(string title);
    }
}
