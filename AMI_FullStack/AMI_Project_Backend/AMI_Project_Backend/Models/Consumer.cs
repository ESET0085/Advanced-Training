using System;
using System.Collections.Generic;

namespace AMI_Project_Backend.Models;

public partial class Consumer
{
    public long ConsumerId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int OrgUnitId { get; set; }

    public int TariffId { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<Billing> Billings { get; set; } = new List<Billing>();

    public virtual ICollection<Meter> Meters { get; set; } = new List<Meter>();

    public virtual OrgUnit OrgUnit { get; set; } = null!;

    public virtual Tariff Tariff { get; set; } = null!;
}
