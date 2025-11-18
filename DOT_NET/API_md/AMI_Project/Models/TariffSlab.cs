using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AMI_Project.Models;

[Table("TariffSlab", Schema = "ami")]
public partial class TariffSlab
{
    [Key]
    public int TariffSlabId { get; set; }

    public int TariffId { get; set; }

    [Column(TypeName = "decimal(18, 6)")]
    public decimal FromKwh { get; set; }

    [Column(TypeName = "decimal(18, 6)")]
    public decimal ToKwh { get; set; }

    [Column(TypeName = "decimal(18, 6)")]
    public decimal RatePerKwh { get; set; }

    [ForeignKey("TariffId")]
    [InverseProperty("TariffSlabs")]
    public virtual Tariff Tariff { get; set; } = null!;
}
