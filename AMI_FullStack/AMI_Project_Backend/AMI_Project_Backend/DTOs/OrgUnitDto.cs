using System.ComponentModel.DataAnnotations;

namespace AMI_Project_Backend.DTOs
{
    public class OrgUnitDto
    {
        [Required]
        public int OrgUnitId { get; set; }

        [Required(ErrorMessage = "Organization unit type is required.")]
        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters.")]
        public string Type { get; set; } = string.Empty;

        [Required(ErrorMessage = "Organization unit name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        public int? ParentId { get; set; }
    }
}
