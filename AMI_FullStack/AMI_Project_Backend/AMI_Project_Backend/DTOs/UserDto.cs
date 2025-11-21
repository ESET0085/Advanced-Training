using System.ComponentModel.DataAnnotations;

namespace AMI_Project_Backend.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format. Must be like abc@xyz.com")]
        public string? Email { get; set; }
        [Phone]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
