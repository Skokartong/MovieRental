﻿using Microsoft.AspNetCore.Http;
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

            return Ok(rentalsList);
        }

        [HttpGet]
        [Route("GetRentalById")]
        public async Task<IActionResult> GetRentalById(int rentalId)
        {
            var rental = await _rentalService.GetRentalByIdAsync(rentalId);
            return Ok(rental);
        }

        [HttpPost]
        [Route("RentMovie")]
        public async Task<IActionResult> RentMovie([FromBody] RentalDTO rentalDTO)
        {
            await _rentalService.RentMovieAsync(rentalDTO);
            return Ok(rentalDTO);
        }

        [HttpPost]
        [Route("ReturnMovie")]
        public async Task<IActionResult> ReturnMovie([FromBody] RentalDTO rentalDTO)
        {
            await _rentalService.ReturnMovieAsync(rentalDTO);
            return Ok(rentalDTO);
        }

        [HttpDelete]
        [Route("DeleteRental")]
        public async Task<ActionResult> DeleteRental(int rentalId)
        {
            await _rentalService.DeleteRentalAsync(rentalId);
            return Ok(rentalId);
        }
    }
}