using System;
using System.Collections.Generic;

namespace AMI_Project_Backend.Models;

public partial class User
{
    public int UserId { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!; // hashed
    public string Role { get; set; } = "User";

    // Optional contact fields (match your DB)
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    // Timestamps (match your DB: CreatedAt NOT NULL, LastLogin NULLABLE)
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLogin { get; set; }
}
