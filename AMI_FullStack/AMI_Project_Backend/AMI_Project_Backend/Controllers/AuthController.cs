using AMI_Project_Backend.DTOs;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AMI_Project_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthController(IRepository<User> userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _passwordHasher = new PasswordHasher<User>();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest(new { message = "Username and password are required." });

            var users = await _userRepository.GetAllAsync();

            // 🔹 Check for duplicate username
            if (users.Any(u => u.Username.Equals(dto.Username, StringComparison.OrdinalIgnoreCase)))
                return Conflict(new { message = "Username already exists." });

            // 🔹 Check for duplicate email
            if (!string.IsNullOrWhiteSpace(dto.Email) &&
                users.Any(u => u.Email != null && u.Email.Equals(dto.Email, StringComparison.OrdinalIgnoreCase)))
                return Conflict(new { message = "Email already exists." });

            // 🔹 Check for duplicate phone number
            if (!string.IsNullOrWhiteSpace(dto.PhoneNumber) &&
                users.Any(u => u.PhoneNumber != null && u.PhoneNumber.Equals(dto.PhoneNumber, StringComparison.OrdinalIgnoreCase)))
                return Conflict(new { message = "Phone number already exists." });

            var newUser = new User
            {
                Username = dto.Username,
                Role = string.IsNullOrWhiteSpace(dto.Role) ? "User" : dto.Role,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                CreatedAt = DateTime.UtcNow
            };

            newUser.Password = _passwordHasher.HashPassword(newUser, dto.Password);

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveAsync();

            var response = new UserDto
            {
                UserId = newUser.UserId,
                Username = newUser.Username,
                Role = newUser.Role,
                Email = newUser.Email,
                PhoneNumber = newUser.PhoneNumber,
                CreatedAt = newUser.CreatedAt,
                LastLogin = newUser.LastLogin
            };

            return Ok(new { message = "User registered successfully", user = response });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var users = await _userRepository.GetAllAsync();
            var user = users.FirstOrDefault(u =>
                u.Username.Equals(dto.Username, StringComparison.OrdinalIgnoreCase));

            if (user == null)
                return Unauthorized(new { message = "Invalid username or password" });

            var hasher = new PasswordHasher<User>();
            bool passwordValid = false;

            try
            {
                var result = hasher.VerifyHashedPassword(user, user.Password, dto.Password);
                passwordValid = result == PasswordVerificationResult.Success;
            }
            catch (FormatException)
            {
                // Password field contained plain text (not a hash)
                // Fall back to direct comparison for legacy data
                passwordValid = user.Password == dto.Password;
            }

            if (!passwordValid)
                return Unauthorized(new { message = "Invalid username or password" });

            // If legacy password matched, re-hash and update for next time
            if (!user.Password.StartsWith("AQAAAA")) // typical hash prefix
            {
                user.Password = hasher.HashPassword(user, dto.Password);
                user.LastLogin = DateTime.UtcNow;
                _userRepository.Update(user);
                await _userRepository.SaveAsync();
            }
            else
            {
                user.LastLogin = DateTime.UtcNow;
                _userRepository.Update(user);
                await _userRepository.SaveAsync();
            }

            var token = GenerateJwtToken(user);
            return Ok(new
            {
                token,
                role = user.Role,
                username = user.Username,
                email = user.Email,
                LastLogin = user.LastLogin
            });

        }

        private string GenerateJwtToken(User user)
        {
            var jwtSection = _configuration.GetSection("Jwt");
            var keyString = jwtSection["Key"];
            if (string.IsNullOrEmpty(keyString))
                throw new InvalidOperationException("JWT Key is not configured.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(ClaimTypes.Role, user.Role ?? "User"),   // <- standard role claim for Authorize(Roles=...)
                new Claim("role", user.Role ?? "User"),            // <- keep this for compatibility if you read 'role' elsewhere
                new Claim("email", user.Email ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
};

            var duration = double.TryParse(jwtSection["DurationInMinutes"], out var m) ? m : 60.0;

            var token = new JwtSecurityToken(
                issuer: jwtSection["Issuer"],
                audience: jwtSection["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(duration),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
