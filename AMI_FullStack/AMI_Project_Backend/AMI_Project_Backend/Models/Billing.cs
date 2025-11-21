using System;
using System.Collections.Generic;

namespace AMI_Project_Backend.Models;

public partial class Billing
{
    public long BillId { get; set; }

    public long ConsumerId { get; set; }

    public string MeterSerialNo { get; set; } = null!;

    public DateOnly BillingPeriodStart { get; set; }

    public DateOnly BillingPeriodEnd { get; set; }

    public decimal UnitsConsumed { get; set; }

    public decimal Amount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime GeneratedDate { get; set; }

    public string? Status { get; set; }

    public virtual Consumer Consumer { get; set; } = null!;

    public virtual Meter MeterSerialNoNavigation { get; set; } = null!;
}
