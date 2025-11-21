using System.ComponentModel.DataAnnotations;

namespace AMI_Project_Backend.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(100, ErrorMessage = "Username cannot exceed 100 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_.-]+$",
              ErrorMessage = "Username can only contain letters, numbers, and '.', '-', '_'")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6,
            ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = string.Empty;
    }
}
