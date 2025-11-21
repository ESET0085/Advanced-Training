using AMI_Project_Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Net;

namespace AMI_Project_Backend.DTOs
{
    public class MeterDto
    {
        [JsonPropertyName("serialNo")]
        [Required(ErrorMessage = "Meter serial number is required.")]
        [RegularExpression(@"^MTR-\d{5}$", ErrorMessage = "Meter serial number must be in format MTR-XXXXX (e.g., MTR-12345).")]
        public string SerialNo { get; set; } = string.Empty;

        [JsonPropertyName("consumerId")]
        [Required(ErrorMessage = "Consumer ID is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Consumer ID must be numeric.")]
        public string ConsumerId { get; set; } = string.Empty;

        [JsonPropertyName("ipAddress")]
        [Required(ErrorMessage = "IP Address is required.")]
        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "Invalid IP address format.")]
        public string IpAddress { get; set; } = string.Empty;

        [JsonPropertyName("iccid")]
        [Required(ErrorMessage = "ICCID is required.")]
        [StringLength(20, MinimumLength = 19, ErrorMessage = "ICCID must be between 19 and 20 digits.")]
        [RegularExpression(@"^\d{19,20}$", ErrorMessage = "ICCID must contain only digits.")]
        public string Iccid { get; set; } = string.Empty;

        [JsonPropertyName("imsi")]
        [Required(ErrorMessage = "IMSI is required.")]
        [StringLength(15, MinimumLength = 14, ErrorMessage = "IMSI must be 14–15 digits long.")]
        [RegularExpression(@"^\d{14,15}$", ErrorMessage = "IMSI must contain only digits.")]
        public string Imsi { get; set; } = string.Empty;

        [JsonPropertyName("manufacturer")]
        [Required(ErrorMessage = "Manufacturer is required.")]
        [StringLength(100, ErrorMessage = "Manufacturer name too long (max 100 chars).")]
        public string Manufacturer { get; set; } = string.Empty;

        [JsonPropertyName("firmware")]
        [StringLength(50, ErrorMessage = "Firmware version too long (max 50 chars).")]
        public string Firmware { get; set; } = string.Empty;

        [JsonPropertyName("category")]
        [Required(ErrorMessage = "Category is required.")]
        [RegularExpression(@"^(SinglePhase|ThreePhase|CT|LT|HT)$", ErrorMessage = "Category must be one of: SinglePhase, ThreePhase, CT, LT, HT.")]
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("installDate")]
        [Required(ErrorMessage = "Install date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format. Expected format: yyyy-MM-dd.")]
        public string InstallDate { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        [Required(ErrorMessage = "Status is required.")]
        [RegularExpression(@"^(Active|Inactive|Faulty|Disconnected)$", ErrorMessage = "Status must be one of: Active, Inactive, Faulty, Disconnected.")]
        public string Status { get; set; } = string.Empty;

        // -------------------------------
        // Mapping methods
        // -------------------------------
        public static MeterDto FromMeter(Meter meter)
        {
            return new MeterDto
            {
                SerialNo = meter.MeterSerialNo,
                ConsumerId = meter.ConsumerId?.ToString() ?? string.Empty,
                IpAddress = meter.IpAddress ?? string.Empty,
                Iccid = meter.Iccid ?? string.Empty,
                Imsi = meter.Imsi ?? string.Empty,
                Manufacturer = meter.Manufacturer ?? string.Empty,
                Firmware = meter.Firmware ?? string.Empty,
                Category = meter.Category ?? string.Empty,
                InstallDate = meter.InstallTsUtc.ToLocalTime().ToString("yyyy-MM-dd"),
                Status = meter.Status ?? string.Empty
            };
        }

        public Meter ToMeter()
        {
            return new Meter
            {
                MeterSerialNo = this.SerialNo,
                ConsumerId = long.TryParse(this.ConsumerId, out var cId) ? cId : (long?)null,
                IpAddress = this.IpAddress,
                Iccid = this.Iccid,
                Imsi = this.Imsi,
                Manufacturer = this.Manufacturer,
                Firmware = string.IsNullOrEmpty(this.Firmware) ? null : this.Firmware,
                Category = this.Category,
                InstallTsUtc = DateTime.TryParse(this.InstallDate, out var date)
                    ? DateTime.SpecifyKind(date, DateTimeKind.Local).ToUniversalTime()
                    : DateTime.UtcNow,
                Status = this.Status
            };
        }

        public void UpdateMeter(Meter meter)
        {
            meter.ConsumerId = long.TryParse(this.ConsumerId, out var cId) ? cId : (long?)null;
            meter.IpAddress = this.IpAddress;
            meter.Iccid = this.Iccid;
            meter.Imsi = this.Imsi;
            meter.Manufacturer = this.Manufacturer;
            meter.Firmware = string.IsNullOrEmpty(this.Firmware) ? null : this.Firmware;
            meter.Category = this.Category;
            meter.InstallTsUtc = DateTime.TryParse(this.InstallDate, out var date)
                ? DateTime.SpecifyKind(date, DateTimeKind.Local).ToUniversalTime()
                : meter.InstallTsUtc;
            meter.Status = this.Status;
        }
    }
}
