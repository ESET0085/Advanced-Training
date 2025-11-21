//using AMI_Project_Backend.Models;

//namespace AMI_Project_Backend.Interfaces
//{
//    public interface IBillingService
//    {
//        Task GenerateBillForConsumerAsync(long consumerId, DateTime periodStart, DateTime periodEnd);
//        Task GenerateBillForMeterAsync(string meterSerialNo, DateTime periodStart, DateTime periodEnd);

//        // NEW: calculate-only (no DB writes) versions that read MeterReading / Meter / Consumer
//        Task<ConsumerBillingResult> CalculateBillForConsumerAsync(long consumerId, DateTime periodStart, DateTime periodEnd);
//        Task<Billing> CalculateBillForMeterAsync(string meterSerialNo, DateTime periodStart, DateTime periodEnd);
//    }

//    public class ConsumerBillingResult
//    {
//        public long ConsumerId { get; set; }
//        public DateTime PeriodStart { get; set; }
//        public DateTime PeriodEnd { get; set; }
//        public decimal TotalUnits { get; set; }
//        public decimal TotalAmount { get; set; }     // includes tax
//        public decimal TotalTax { get; set; }
//        public List<Billing> PerMeterBills { get; set; } = new();
//    }
//}
using AMI_Project_Backend.DTOs;

namespace AMI_Project_Backend.Interfaces
{
    public interface IBillingService
    {
        /// <summary>
        /// Generate and persist monthly bill for a specific meter
        /// </summary>
        BillingDto? GenerateMonthlyBillForMeter(string meterSerialNo, DateTime billingDate);

        /// <summary>
        /// Generate and persist monthly bills for all active meters
        /// </summary>
        List<BillingDto> GenerateMonthlyBills(DateTime billingDate);

        /// <summary>
        /// Get all persisted bills
        /// </summary>
        List<BillingDto> GetAllBills();
    }
}
