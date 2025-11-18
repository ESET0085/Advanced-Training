using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AMI_Project.Models;

[Table("Billing", Schema = "ami")]
public partial class Billing
{
    [Key]
    public long BillId { get; set; }

    public long ConsumerId { get; set; }

    public DateOnly BillingPeriodStart { get; set; }

    public DateOnly BillingPeriodEnd { get; set; }

    [Column(TypeName = "decimal(18, 6)")]
    public decimal TotalKwh { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal AmountBeforeTax { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal TaxAmount { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal TotalAmount { get; set; }

    [Precision(3)]
    public DateTime GeneratedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [ForeignKey("ConsumerId")]
    [InverseProperty("Billings")]
    public virtual Consumer Consumer { get; set; } = null!;
}
