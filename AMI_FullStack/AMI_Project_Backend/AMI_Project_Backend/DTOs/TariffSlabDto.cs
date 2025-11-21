using System.ComponentModel.DataAnnotations;

namespace AMI_Project_Backend.DTOs
{
    public class TariffSlabDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "TariffSlabId must be a positive number.")]
        public int? TariffSlabId { get; set; }  // nullable to allow POST without ID

        [Required(ErrorMessage = "Tariff ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "TariffId must be a positive number.")]
        public int TariffId { get; set; }

        [Required(ErrorMessage = "FromKwh is required.")]
        [Range(0, 999999, ErrorMessage = "FromKwh must be non-negative.")]
        public decimal FromKwh { get; set; }

        [Required(ErrorMessage = "ToKwh is required.")]
        [Range(0.01, 999999, ErrorMessage = "ToKwh must be greater than 0.")]
        public decimal ToKwh { get; set; }

        [Required(ErrorMessage = "Rate per kWh is required.")]
        [Range(0.01, 100000, ErrorMessage = "Rate per kWh must be greater than 0.")]
        public decimal RatePerKwh { get; set; }
    }
}
