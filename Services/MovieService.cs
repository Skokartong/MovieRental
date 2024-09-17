using Microsoft.AspNetCore.Http.HttpResults;
using MovieRental.Data.Repos.IRepos;
using MovieRental.Models;
using MovieRental.Models.DTOs;
using MovieRental.Services.IServices;

namespace MovieRental.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task AddMovieAsync(MovieDTO movieDTO)
        {
            var movie = new Movie
            {
                Id = movieDTO.Id,
                Title = movieDTO.Title,
                Genre = movieDTO.Genre,
                Year = movieDTO.Year,
                Description = movieDTO.Description
            };

            await _movieRepository.AddMovieAsync(movie);
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);

            if (movie == null)
            {
                throw new Exception("Movie not found");
            }

            await _movieRepository.DeleteMovieAsync(movie);
        }

        public async Task<bool> UpdateMovieAsync(MovieDTO movieDTO)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(movieDTO.Id);

            if (movie == null)
            {
                throw new Exception("Movie not found");
            }

            if (movie != null)
            {
                movie.Title = movieDTO.Title;
                movie.Description = movieDTO.Description;
                movie.Genre = movieDTO.Genre;
                movie.Year = movieDTO.Year;

                await _movieRepository.UpdateMovieAsync(movie);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<MovieDTO>> GetAllMoviesAsync()
        {
            var moviesList = await _movieRepository.GetAllMoviesAsync();

            return moviesList.Select(m => new MovieDTO
            {
                Id = m.Id,
                Title = m.Title,
                Genre = m.Genre,
                Year = m.Year,
                Description = m.Description
            }).ToList();
        }

        public async Task<MovieDTO?> GetMovieByIdAsync(int id)
        {
            var movieFound = await _movieRepository.GetMovieByIdAsync(id);

            if (movieFound != null)
            {
                var movie = new MovieDTO
                {
                    Id = movieFound.Id,
                    Title = movieFound.Title,
                    Description = movieFound.Description,
                    Year = movieFound.Year,
                    Genre = movieFound.Genre
                };

                return movie;
            }

            return null;
        }

        public async Task<IEnumerable<MovieDTO>> SearchMoviesByGenreAsync(string genre)
        {
            var movies = await _movieRepository.GetMoviesByGenreAsync(genre);

            if (movies != null)
            {
                return movies.Select(m => new MovieDTO
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                    Genre = m.Genre,
                    Description = m.Description
                }).ToList();
            }

            return null;
        }

        public async Task<MovieDTO> SearchMovieByNameAsync(string title)
        {
            var movieFound = await _movieRepository.GetMovieByTitleAsync(title);

            if (movieFound != null)
            {
                var movie = new MovieDTO
                {
                    Id = movieFound.Id,
                    Title = movieFound.Title,
                    Description = movieFound.Description,
                    Year = movieFound.Year,
                    Genre = movieFound.Genre
                };

                return movie;
            }

            return null;
        }
    }
}
