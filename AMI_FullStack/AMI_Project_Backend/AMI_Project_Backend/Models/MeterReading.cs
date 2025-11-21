using System;
using System.Collections.Generic;

namespace AMI_Project_Backend.Models;

public partial class MeterReading
{
    public long ReadingId { get; set; }

    public string MeterSerialNo { get; set; } = null!;

    public DateTime ReadingDate { get; set; }

    public decimal Kwh { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Meter MeterSerialNoNavigation { get; set; } = null!;
}
