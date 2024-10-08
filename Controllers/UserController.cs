﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Data.Repos.IRepos;
using MovieRental.Models;
using MovieRental.Models.DTOs;
using MovieRental.Services.IServices;

namespace MovieRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var usersList = await _userService.GetAllUsersAsync();

            return Ok(usersList);
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPut]
        [Route("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDTO)
        {
            await _userService.UpdateUserAsync(id, userDTO);
            return Ok($"User with id {id} now updated: {userDTO}");
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok($"User with id {id} is now deleted");
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult<UserDTO>> AddUser([FromBody] UserDTO userDTO)
        {
            await _userService.AddUserAsync(userDTO);
            return CreatedAtAction(nameof(GetUserById), new { userId = userDTO.Id }, userDTO);
        }
    }
}
