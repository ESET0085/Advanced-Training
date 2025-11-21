using System.ComponentModel.DataAnnotations;

public class ConsumerDto
{
    public long ConsumerId { get; set; }  // No validation attributes here

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
    public string Name { get; set; } = string.Empty;

    public string? Address { get; set; }

    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits")]
    public string? Phone { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(150, ErrorMessage = "Email cannot exceed 150 characters")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "OrgUnitId is required")]
    [Range(1, int.MaxValue, ErrorMessage = "OrgUnitId must be a positive number")]
    public int OrgUnitId { get; set; }

    [Required(ErrorMessage = "TariffId is required")]
    [Range(1, int.MaxValue, ErrorMessage = "TariffId must be a positive number")]
    public int TariffId { get; set; }

    [Required]
    [RegularExpression("^(Active|Inactive|Suspended)$",
        ErrorMessage = "Status must be either 'Active', 'Inactive', or 'Suspended'")]
    public string Status { get; set; } = "Active";

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [StringLength(100, ErrorMessage = "CreatedBy cannot exceed 100 characters")]
    public string CreatedBy { get; set; } = "System";

    public DateTime? UpdatedAt { get; set; }

    [StringLength(100, ErrorMessage = "UpdatedBy cannot exceed 100 characters")]
    public string? UpdatedBy { get; set; }
}
