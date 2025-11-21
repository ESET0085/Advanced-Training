using System;
using System.Collections.Generic;

namespace AMI_Project_Backend.Models;

public partial class Meter
{
    public string MeterSerialNo { get; set; } = null!;

    public string IpAddress { get; set; } = null!;

    public string Iccid { get; set; } = null!;

    public string Imsi { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public string? Firmware { get; set; }

    public string Category { get; set; } = null!;

    public DateTime InstallTsUtc { get; set; }

    public string Status { get; set; } = null!;

    public long? ConsumerId { get; set; }

    public virtual ICollection<Billing> Billings { get; set; } = new List<Billing>();

    public virtual Consumer? Consumer { get; set; }

    public virtual ICollection<MeterReading> MeterReadings { get; set; } = new List<MeterReading>();
}
