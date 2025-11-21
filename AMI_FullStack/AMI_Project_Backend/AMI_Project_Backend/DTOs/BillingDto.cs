namespace AMI_Project_Backend.DTOs
{
    public class BillingDto
    {
        public long BillId { get; set; }
        public long ConsumerId { get; set; }
        public string MeterSerialNo { get; set; } = string.Empty;
        public DateTime BillingPeriodStart { get; set; }
        public DateTime BillingPeriodEnd { get; set; }
        public decimal UnitsConsumed { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime GeneratedDate { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
