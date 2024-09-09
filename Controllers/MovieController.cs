using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(movieDTO);
        }

        [HttpGet]
        [Route("GetMovies")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            var moviesList = await _movieService.GetAllMoviesAsync();
            return Ok(moviesList);
        }

        [HttpPut]
        [Route("UpdateMovie")]
        public async Task<IActionResult> UpdateMovie(int movieId)
        {

        }

        [HttpGet]
        [Route("SearchMovieTitle")]
        public async Task<IActionResult> SearchMovieTitle(string title)
        {
            var movie = await _movieService.SearchMovieByNameAsync(title);
            return Ok(movie);
        }

        [HttpGet]
        [Route("SearchMovieId")]
        public async Task<IActionResult> SearchMovieId(int movieId)
        {
            var movie = await _movieService.GetMovieByIdAsync(movieId);
            return Ok(movie);
        }

        [HttpGet]
        [Route("SearchMovieGenre")]
        public async Task<IActionResult> SearchMovieGenre(string genre)
        {
            var movie = await _movieService.SearchMoviesByGenreAsync(genre);
            return Ok(movie);
        }

        [HttpDelete]
        [Route("DeleteMovie")]
        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            await _movieService.DeleteMovieAsync(movieId);
            return Ok();
        }
    }
}
