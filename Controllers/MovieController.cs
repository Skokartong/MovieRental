using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Models;
using MovieRental.Models.DTOs;
using MovieRental.Services;
using MovieRental.Services.IServices;

namespace MovieRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        [Route("AddMovie")]
        public async Task<IActionResult> AddMovie([FromBody] MovieDTO movieDTO)
        {
            await _movieService.AddMovieAsync(movieDTO);
            return Ok();
        }

        [HttpGet]
        [Route("GetMovies")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            var moviesList = await _movieService.GetAllMoviesAsync();
            return Ok(moviesList);
        }

        [HttpPut]
        [Route("UpdateMovie/{movieId}")]
        public async Task<IActionResult> UpdateMovie(int movieId,[FromBody] MovieDTO movieDTO)
        {
            if (movieDTO == null)
            {
                return BadRequest("Movie data cannot be null");
            }

            if (movieId != movieDTO.Id)
            {
                return BadRequest("Movie ID mismatch");
            }

            var movie = await _movieService.GetMovieByIdAsync(movieId);

            if (movie == null)
            {
                return NotFound("Movie not found");
            }

            await _movieService.UpdateMovieAsync(movieId, movieDTO);

            return NoContent();
        }

        [HttpGet]
        [Route("SearchMovieTitle/{title}")]
        public async Task<IActionResult> SearchMovieTitle(string title)
        {
            var movie = await _movieService.SearchMovieByNameAsync(title);
            return Ok();
        }

        [HttpGet]
        [Route("SearchMovieId/{movieId}")]
        public async Task<IActionResult> SearchMovieId(int movieId)
        {
            var movie = await _movieService.GetMovieByIdAsync(movieId);
            return Ok();
        }

        [HttpGet]
        [Route("SearchMovieGenre/{genre}")]
        public async Task<IActionResult> SearchMovieGenre(string genre)
        {
            var movie = await _movieService.SearchMoviesByGenreAsync(genre);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteMovie/{movieId}")]
        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            var movie = await _movieService.GetMovieByIdAsync(movieId);
            if (movie == null)
            {
                return NotFound();
            }

            await _movieService.DeleteMovieAsync(movieId);
            return NoContent();
        }
    }
}
