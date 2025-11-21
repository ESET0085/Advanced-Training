using System;
using System.ComponentModel.DataAnnotations;

namespace AMI_Project_Backend.DTOs
{
    public class MeterReadingDto
    {
        //[Range(1, long.MaxValue, ErrorMessage = "Reading ID must be a positive number")]
        //public long ReadingId { get; set; }

        [Required(ErrorMessage = "MeterSerialNo is required")]
        [StringLength(50, ErrorMessage = "MeterSerialNo cannot exceed 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9\-]+$", ErrorMessage = "MeterSerialNo can only contain letters, numbers, and hyphens")]
        public string MeterSerialNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "ReadingDate is required")]
        public DateTime ReadingDate { get; set; }

        [Required(ErrorMessage = "Kwh is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Kwh must be greater than 0")]
        public decimal Kwh { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
