using CollegeProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CollegeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly CollegeDbContext _context;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger, IConfiguration configuration, CollegeDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;
        }


        public AuthController(IConfiguration configuration,CollegeDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // ✅ Hardcoded credentials for demo

            var user = _context.Users.Where(u=>u.Username == model.Username && u.PasswordHash==model.Password).FirstOrDefault();
            if (user == null) {
                return NotFound();
            }
            if (user.Role=="Admin")
            {
                string token = GenerateJwtToken(model.Username);
                return Ok(new { token });
            }

            return Unauthorized("Invalid Credentials");
        }

        private string GenerateJwtToken(string username)
        {
            // ✅ Get key from appsettings.json
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // ✅ Define claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // ✅ Create JWT token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
                signingCredentials: creds
            );

            // ✅ Return serialized token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    // ✅ Login model
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
