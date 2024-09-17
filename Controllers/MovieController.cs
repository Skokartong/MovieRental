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
            return CreatedAtAction(nameof(AddMovie), new { movieDTO });
        }

        [HttpGet]
        [Route("GetMovies")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            var moviesList = await _movieService.GetAllMoviesAsync();
            return Ok(moviesList);
        }

        [HttpPut]
        [Route("UpdateMovie/{id}")]
        public async Task<IActionResult> UpdateMovie(int id,[FromBody] MovieDTO movieDTO)
        {
            if (id != movieDTO.Id)
            {
                return BadRequest("Movie ID mismatch");
            }

            await _movieService.UpdateMovieAsync(movieDTO);
            return NoContent(); 
        }

        [HttpGet]
        [Route("GetMovieById/{id}")]
        public async Task<IActionResult> SearchMovieId(int id)
        {
            var movieDTO = await _movieService.GetMovieByIdAsync(id);
            if (movieDTO == null)
            {
                return NotFound();
            }
            return Ok(movieDTO);
        }

        [HttpGet]
        [Route("SearchMovieTitle/{title}")]
        public async Task<IActionResult> SearchMovieTitle(string title)
        {
            var movie = await _movieService.SearchMovieByNameAsync(title);
            return Ok(movie);
        }

        [HttpGet]
        [Route("SearchMovieGenre/{genre}")]
        public async Task<IActionResult> SearchMovieGenre(string genre)
        {
            var movieDTO = await _movieService.SearchMoviesByGenreAsync(genre);
            return Ok(movieDTO);
        }

        [HttpDelete]
        [Route("DeleteMovie/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movieDTO = await _movieService.GetMovieByIdAsync(id);
            if (movieDTO == null)
            {
                return NotFound();
            }

            await _movieService.DeleteMovieAsync(id);
            return NoContent();
        }
    }
}
