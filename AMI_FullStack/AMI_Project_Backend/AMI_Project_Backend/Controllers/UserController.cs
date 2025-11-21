using AMI_Project_Backend.DTOs;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMI_Project_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = new PasswordHasher<User>();
        }

        // ----------------------------------------------------------
        // 1️⃣ GET ALL USERS
        // ----------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // ✅ returns validation errors
            var users = await _userRepository.GetAllAsync();
            var userDtos = users.Select(u => new UserDto
            {
                UserId = u.UserId,
                Username = u.Username,
                Role = u.Role,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                CreatedAt = u.CreatedAt,
                LastLogin = u.LastLogin
            });

            return Ok(userDtos);
        }

        // ----------------------------------------------------------
        // 2️⃣ GET USER BY ID
        // ----------------------------------------------------------
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // ✅ returns validation errors
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            var dto = new UserDto
            {
                UserId = user.UserId,
                Username = user.Username,
                Role = user.Role,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CreatedAt = user.CreatedAt,
                LastLogin = user.LastLogin
            };

            return Ok(dto);
        }

        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // ✅ returns validation errors
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            // Update editable fields
            user.Username = dto.Username ?? user.Username;
            user.Role = string.IsNullOrWhiteSpace(dto.Role) ? user.Role : dto.Role;
            user.Email = dto.Email ?? user.Email;
            user.PhoneNumber = dto.PhoneNumber ?? user.PhoneNumber;

            // If password is provided, re-hash and update
            if (!string.IsNullOrWhiteSpace(dto.Password))
                user.Password = _passwordHasher.HashPassword(user, dto.Password);

            // Save changes
            try
            {
                _userRepository.Update(user);
            }
            catch
            {
                // some repositories auto-track, so this is optional
            }

            await _userRepository.SaveAsync();

            var response = new UserDto
            {
                UserId = user.UserId,
                Username = user.Username,
                Role = user.Role,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CreatedAt = user.CreatedAt,
                LastLogin = user.LastLogin
            };

            return Ok(new { message = "User updated successfully", user = response });
        }

        // ----------------------------------------------------------
        // 5️⃣ DELETE USER
        // ----------------------------------------------------------
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // ✅ returns validation errors
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            _userRepository.Delete(user);

            await _userRepository.SaveAsync();

            return Ok(new { message = "User deleted successfully" });
        }

        
    }
}
