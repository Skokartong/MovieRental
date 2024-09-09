using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Models.DTOs;
using MovieRental.Services;
using MovieRental.Services.IServices;

namespace MovieRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        [Route("GetRentals")]
        public async Task<ActionResult<IEnumerable<RentalDTO>>> GetAllRentals()
        {
            var rentalsList = await _rentalService.GetAllRentalsAsync();

            return Ok();
        }

        [HttpGet]
        [Route("GetRentalById/{id}")]
        public async Task<IActionResult> GetRentalById(int id)
        {
            var rental = await _rentalService.GetRentalByIdAsync(id);
            return Ok();
        }

        [HttpPost]
        [Route("RentMovie")]
        public async Task<IActionResult> RentMovie(int id, [FromBody] RentalDTO rentalDTO)
        {
            await _rentalService.RentMovieAsync(id, rentalDTO);
            return Ok();
        }

        [HttpPost]
        [Route("ReturnMovie/{id}")]
        public async Task<IActionResult> ReturnMovie(int id)
        {
            await _rentalService.ReturnMovieAsync(id);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteRental/{id}")]
        public async Task<ActionResult> DeleteRental(int id)
        {
            await _rentalService.DeleteRentalAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateRental/{rentalId}")]
        public async Task<IActionResult> UpdateRental(int id, RentalDTO rentalDTO)
        {
            await _rentalService.UpdateRentalAsync(id, rentalDTO);
            return Ok();
        }
    }
}
