using AMI_Project_Backend.Data;
using AMI_Project_Backend.DTOs;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AMI_Project_Backend.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly AMIDbContext _context;

        public DataRepository(AMIDbContext context)
        {
            _context = context;
        }

        public List<MeterDto> GetAllMeters()
        {
            return _context.Meters
                .Where(m => m.Status == "Active")
                .Select(m => new MeterDto
                {
                    SerialNo = m.MeterSerialNo,
                    ConsumerId = m.ConsumerId.ToString(),
                    Category = m.Category,
                    Status = m.Status,
                    Manufacturer = m.Manufacturer,
                    InstallDate = m.InstallTsUtc.ToLocalTime().ToString("yyyy-MM-dd"),
                    Iccid = m.Iccid,
                    Imsi = m.Imsi,
                    IpAddress = m.IpAddress
                })
                .ToList();
        }

        public List<MeterReadingDto> GetMeterReadings(string meterSerialNo, DateTime periodStart, DateTime periodEnd)
        {
            return _context.MeterReadings
                .Where(r => r.MeterSerialNo == meterSerialNo && r.ReadingDate >= periodStart && r.ReadingDate <= periodEnd)
                .Select(r => new MeterReadingDto
                {
                    MeterSerialNo = r.MeterSerialNo,
                    ReadingDate = r.ReadingDate,
                    Kwh = r.Kwh,
                    CreatedAt = r.CreatedAt
                })
                .ToList();
        }

        public ConsumerDto? GetConsumerById(long consumerId)
        {
            var c = _context.Consumers.FirstOrDefault(c => c.ConsumerId == consumerId);
            if (c == null) return null;

            return new ConsumerDto
            {
                ConsumerId = c.ConsumerId,
                Name = c.Name,
                TariffId = c.TariffId,
                OrgUnitId = c.OrgUnitId,
                Status = c.Status
            };
        }

        public TariffDto? GetTariffById(int tariffId)
        {
            var t = _context.Tariffs.FirstOrDefault(t => t.TariffId == tariffId);
            if (t == null) return null;

            return new TariffDto
            {
                TariffId = t.TariffId,
                Name = t.Name,
                BaseRate = t.BaseRate,
                TaxRate = t.TaxRate,
                EffectiveFrom = t.EffectiveFrom,
                EffectiveTo = t.EffectiveTo.HasValue ? t.EffectiveTo.Value : null
            };
        }

        public List<TariffSlabDto> GetTariffSlabs(int tariffId)
        {
            return _context.TariffSlabs
                .Where(s => s.TariffId == tariffId)
                .OrderBy(s => s.FromKwh)
                .Select(s => new TariffSlabDto
                {
                    TariffSlabId = s.TariffSlabId,
                    TariffId = s.TariffId,
                    FromKwh = s.FromKwh,
                    ToKwh = s.ToKwh,
                    RatePerKwh = s.RatePerKwh
                })
                .ToList();
        }

        public void SaveBills(List<BillingDto> bills)
        {
            foreach (var b in bills)
            {
                _context.Billings.Add(new Billing
                {
                    ConsumerId = b.ConsumerId,
                    MeterSerialNo = b.MeterSerialNo,
                    BillingPeriodStart = DateOnly.FromDateTime(b.BillingPeriodStart),
                    BillingPeriodEnd = DateOnly.FromDateTime(b.BillingPeriodEnd),
                    UnitsConsumed = b.UnitsConsumed,
                    Amount = b.Amount,
                    TaxAmount = b.TaxAmount,
                    TotalAmount = b.TotalAmount,
                    GeneratedDate = b.GeneratedDate,
                    Status = b.Status
                });
            }
            _context.SaveChanges();
        }

        public List<BillingDto> GetAllBills()
        {
            return _context.Billings
                .Select(b => new BillingDto
                {
                    BillId = b.BillId,
                    ConsumerId = b.ConsumerId,
                    MeterSerialNo = b.MeterSerialNo,
                    BillingPeriodStart = b.BillingPeriodStart.ToDateTime(TimeOnly.MinValue),
                    BillingPeriodEnd = b.BillingPeriodEnd.ToDateTime(TimeOnly.MinValue),
                    UnitsConsumed = b.UnitsConsumed,
                    Amount = b.Amount,
                    TaxAmount = b.TaxAmount,
                    TotalAmount = b.TotalAmount,
                    GeneratedDate = b.GeneratedDate,
                    Status = b.Status
                })
                .ToList();
        }
    }
}
