using System.ComponentModel.DataAnnotations;

namespace AMI_Project_Backend.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9_.-]+$", ErrorMessage = "Username can only contain letters, numbers, dots, underscores, or hyphens.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must contain uppercase, lowercase, number, and special character.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role is required.")]
        [RegularExpression(@"^(Admin|User|Manager)$", ErrorMessage = "Role must be Admin, User, or Manager.")]
        public string Role { get; set; } = "User";

        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        //[Phone(ErrorMessage = "Invalid phone number format.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits")]
        public string? PhoneNumber { get; set; }
    }
}
