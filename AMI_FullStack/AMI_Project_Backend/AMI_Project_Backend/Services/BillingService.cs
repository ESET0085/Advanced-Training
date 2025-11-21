using AMI_Project_Backend.DTOs;
using AMI_Project_Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AMI_Project_Backend.Services
{
    public class BillingService : IBillingService
    {
        private readonly IDataRepository _repository;

        public BillingService(IDataRepository repository)
        {
            _repository = repository;
        }

        // Generate bill for a single meter
        public BillingDto? GenerateMonthlyBillForMeter(string meterSerialNo, DateTime billingDate)
        {
            var meter = _repository.GetAllMeters()
                .FirstOrDefault(m => m.SerialNo == meterSerialNo && m.Status == "Active");
            if (meter == null) return null;

            if (!long.TryParse(meter.ConsumerId, out var consumerId)) return null;

            var consumer = _repository.GetConsumerById(consumerId);
            if (consumer == null) return null;

            var tariff = _repository.GetTariffById(consumer.TariffId);
            if (tariff == null) return null;

            // Monthly period
            var periodStart = new DateTime(billingDate.Year, billingDate.Month, 1);
            var periodEnd = new DateTime(billingDate.Year, billingDate.Month,
                DateTime.DaysInMonth(billingDate.Year, billingDate.Month), 23, 59, 59);

            // Get all readings of the month
            var readings = _repository.GetMeterReadings(meter.SerialNo, periodStart, periodEnd);
            decimal unitsConsumed = readings.Sum(r => r.Kwh);

            // Slab-based calculation
            var amount = CalculateAmount(unitsConsumed, tariff.TariffId);
            var tax = amount * tariff.TaxRate / 100;
            var total = amount + tax;

            var bill = new BillingDto
            {
                ConsumerId = consumer.ConsumerId,
                MeterSerialNo = meter.SerialNo,
                BillingPeriodStart = periodStart,
                BillingPeriodEnd = periodEnd,
                UnitsConsumed = unitsConsumed,
                Amount = amount,
                TaxAmount = tax,
                TotalAmount = total,
                GeneratedDate = DateTime.UtcNow,
                Status = "Pending"
            };

            // Save bill
            _repository.SaveBills(new List<BillingDto> { bill });

            return bill;
        }

        // Generate bills for all active meters
        public List<BillingDto> GenerateMonthlyBills(DateTime billingDate)
        {
            var meters = _repository.GetAllMeters();
            var bills = new List<BillingDto>();

            foreach (var meter in meters)
            {
                var bill = GenerateMonthlyBillForMeter(meter.SerialNo, billingDate);
                if (bill != null)
                    bills.Add(bill);
            }

            return bills;
        }

        public List<BillingDto> GetAllBills()
        {
            return _repository.GetAllBills();
        }

        // Slab-based progressive calculation
        private decimal CalculateAmount(decimal unitsConsumed, int tariffId)
        {
            var slabs = _repository.GetTariffSlabs(tariffId);
            decimal remainingUnits = unitsConsumed;
            decimal totalAmount = 0;

            foreach (var slab in slabs)
            {
                if (remainingUnits <= 0) break;

                decimal slabUnits = Math.Min(remainingUnits, slab.ToKwh - slab.FromKwh + 1);
                totalAmount += slabUnits * slab.RatePerKwh;
                remainingUnits -= slabUnits;
            }

            return totalAmount;
        }
    }
}
