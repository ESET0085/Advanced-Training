using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AMI_Project.Models;

[Table("User", Schema = "ami")]
[Index("Email", Name = "UQ__User__A9D10534CD730876", IsUnique = true)]
[Index("UserName", Name = "UQ__User__C9F28456828434A6", IsUnique = true)]
public partial class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(100)]
    public string UserName { get; set; } = null!;

    [StringLength(150)]
    public string Email { get; set; } = null!;

    [StringLength(100)]
    public string Password { get; set; } = null!;

    [StringLength(50)]
    public string Role { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Precision(3)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Precision(3)]
    public DateTime? UpdatedAt { get; set; }
}
