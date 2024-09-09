using MovieRental.Models.DTOs;

namespace MovieRental.Services.IServices
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetAllMoviesAsync();
        Task<MovieDTO> GetMovieByIdAsync(int movieId);
        Task AddMovieAsync(MovieDTO movieDTO);
        Task DeleteMovieAsync(int movieId);
        Task UpdateMovieAsync(int movieId, MovieDTO movieDTO);
        Task<IEnumerable<MovieDTO>> SearchMoviesByGenreAsync(string genre);
        Task<MovieDTO> SearchMovieByNameAsync(string title);
    }
}
