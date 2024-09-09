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
        [Route("GetRentalById/{rentalId}")]
        public async Task<IActionResult> GetRentalById(int rentalId)
        {
            var rental = await _rentalService.GetRentalByIdAsync(rentalId);
            return Ok();
        }

        [HttpPost]
        [Route("RentMovie")]
        public async Task<IActionResult> RentMovie([FromBody] RentalDTO rentalDTO)
        {
            await _rentalService.RentMovieAsync(rentalDTO);
            return Ok();
        }

        [HttpPost]
        [Route("ReturnMovie/{rentalId}")]
        public async Task<IActionResult> ReturnMovie(int rentalId)
        {
            await _rentalService.ReturnMovieAsync(rentalId);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteRental/{rentalId}")]
        public async Task<ActionResult> DeleteRental(int rentalId)
        {
            await _rentalService.DeleteRentalAsync(rentalId);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateRental/{rentalId}")]
        public async Task<IActionResult> UpdateRental(int rentalId, RentalDTO rentalDTO)
        {
            await _rentalService.UpdateRentalAsync(rentalId, rentalDTO);
            return Ok();
        }
    }
}
