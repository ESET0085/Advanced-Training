using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AMI_Project.Models;

[Table("Consumer", Schema = "ami")]
public partial class Consumer
{
    [Key]
    public long ConsumerId { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string? Address { get; set; }

    [StringLength(30)]
    public string? Phone { get; set; }

    [StringLength(200)]
    public string? Email { get; set; }

    public int OrgUnitId { get; set; }

    public int TariffId { get; set; }

    [Column(TypeName = "decimal(10, 6)")]
    public decimal? Latitude { get; set; }

    [Column(TypeName = "decimal(10, 6)")]
    public decimal? Longitude { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Precision(3)]
    public DateTime CreatedAt { get; set; }

    [StringLength(100)]
    public string CreatedBy { get; set; } = null!;

    [Precision(3)]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(100)]
    public string? UpdatedBy { get; set; }

    [InverseProperty("Consumer")]
    public virtual ICollection<Billing> Billings { get; set; } = new List<Billing>();

    [InverseProperty("Consumer")]
    public virtual ICollection<Meter> Meters { get; set; } = new List<Meter>();

    [ForeignKey("OrgUnitId")]
    [InverseProperty("Consumers")]
    public virtual OrgUnit OrgUnit { get; set; } = null!;

    [ForeignKey("TariffId")]
    [InverseProperty("Consumers")]
    public virtual Tariff Tariff { get; set; } = null!;
}
