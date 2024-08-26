﻿using Microsoft.Identity.Client;
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
                Title = movieDTO.Title,
                Genre = movieDTO.Genre,
                Year = movieDTO.Year,
                Description = movieDTO.Description
            };

            await _movieRepository.AddMovieAsync(movie);
        }

        public async Task DeleteMovieAsync(int movieId)
        {
            await _movieRepository.DeleteMovieAsync(movieId);
        }

        public async Task<IEnumerable<MovieDTO>> GetAllMoviesAsync()
        {
            var moviesList = await _movieRepository.GetAllMoviesAsync();

            return moviesList.Select(m => new MovieDTO
            {
                Title = m.Title,
                Genre = m.Genre,
                Year = m.Year,
                Description = m.Description
            }).ToList();
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int movieId)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(movieId);

            return new MovieDTO
            {
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Genre = movie.Genre
            };
        }

        public async Task<IEnumerable<MovieDTO>> SearchMoviesByGenreAsync(string genre)
        {
            var movies = await _movieRepository.GetMoviesByGenreAsync(genre);

            return movies.Select(m => new MovieDTO
            {
                Title = m.Title,
                Year = m.Year,
                Genre = m.Genre,
                Description = m.Description
            }).ToList();
        }

        public async Task<MovieDTO> SearchMovieByNameAsync(string title)
        {
            var movie = await _movieRepository.GetMovieByTitleAsync(title);
            return new MovieDTO
            {
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Genre = movie.Genre
            };
        }
    }
}