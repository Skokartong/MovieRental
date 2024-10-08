﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MovieRental.Data.Repos.IRepos;
using MovieRental.Models;

namespace MovieRental.Data.Repos
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieRentalContext _context;

        public MovieRepository(MovieRentalContext context)
        {
            _context = context;
        }
        public async Task AddMovieAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(Movie movie)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
           return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            return movie;
        }
        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            var movie = await _context.Movies
                              .FirstOrDefaultAsync(m => m.Title == title);
            return movie;
        }
        public async Task<List<Movie>> GetMoviesByGenreAsync(string genre)
        {
            return await _context.Movies
                                 .Where(m => m.Genre == genre)
                                 .ToListAsync();
        }
    }
}
