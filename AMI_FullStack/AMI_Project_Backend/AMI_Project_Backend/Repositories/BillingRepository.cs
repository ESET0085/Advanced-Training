using AMI_Project_Backend.Data;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace AMI_Project_Backend.Repositories
{
    public class BillingRepository : Repository<Billing>, IBillingRepository
    {
        public BillingRepository(AMIDbContext context) : base(context) { }

        public async Task<IEnumerable<Billing>> GetByConsumerAsync(long consumerId)
        {
            return await _dbSet.AsNoTracking()
                .Where(b => b.ConsumerId == consumerId)
                .OrderByDescending(b => b.GeneratedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Billing>> GetByPeriodAsync(DateTime periodStart, DateTime periodEnd)
        {
            var startDateOnly = DateOnly.FromDateTime(periodStart);
            var endDateOnly = DateOnly.FromDateTime(periodEnd);

            return await _dbSet.AsNoTracking()
                .Where(b => b.BillingPeriodStart <= endDateOnly && b.BillingPeriodEnd >= startDateOnly)
                .ToListAsync();
        }

        public async Task<IEnumerable<Billing>> GetByMeterAsync(string meterSerialNo)
        {
            return await _dbSet.AsNoTracking()
                .Where(b => b.MeterSerialNo == meterSerialNo)
                .OrderByDescending(b => b.GeneratedDate)
                .ToListAsync();
        }
    }
}
