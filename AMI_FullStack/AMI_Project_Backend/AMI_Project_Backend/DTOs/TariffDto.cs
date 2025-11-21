using System.ComponentModel.DataAnnotations;

namespace AMI_Project_Backend.DTOs
{
    public class TariffDto
    {
        [Key]
        public int TariffId { get; set; }

        [Required(ErrorMessage = "Tariff name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tariff name must be between 3 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Effective From date is required.")]
        public DateOnly EffectiveFrom { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? EffectiveTo { get; set; }

        [Required(ErrorMessage = "Base rate is required.")]
        [Range(0.01, 100000, ErrorMessage = "Base rate must be greater than 0.")]
        public decimal BaseRate { get; set; }

        [Required(ErrorMessage = "Tax rate is required.")]
        [Range(0, 100, ErrorMessage = "Tax rate must be between 0 and 100 percent.")]
        public decimal TaxRate { get; set; }
    }
}
