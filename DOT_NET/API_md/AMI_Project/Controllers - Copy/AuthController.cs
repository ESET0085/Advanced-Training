using AMI_Project.DTOs;
using AMI_Project.Services;
using AMI_Project.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AMI_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly JwtService _jwtService;
        private readonly IMapper _mapper;

        public AuthController(AuthService authService, JwtService jwtService, IMapper mapper)
        {
            _authService = authService;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var user = await _authService.RegisterAsync(dto);
            if (user == null) return BadRequest("User registration failed");

            // Map User -> UserDto before returning
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _authService.LoginAsync(dto);
            if (user == null) return Unauthorized("Invalid credentials");

            var token = _jwtService.GenerateJwtToken(user);

            // Map User -> UserDto before returning
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(new { token, user = userDto });
        }
    }
}
