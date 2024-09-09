using MovieRental.Models;

namespace MovieRental.Data.Repos.IRepos
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<Movie> GetMovieByTitleAsync(string title);
        Task<List<Movie>> GetMoviesByGenreAsync(string genre);
        Task AddMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(Movie movie);
    }
}
