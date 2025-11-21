using AMI_Project_Backend.Data;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace AMI_Project_Backend.Repositories
{
    public class MeterReadingRepository : Repository<MeterReading>, IMeterReadingRepository
    {
        private readonly AMIDbContext _context;

        public MeterReadingRepository(AMIDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MeterReading>> GetByMeterSerialNoAsync(string meterSerialNo)
        {
            return await _context.MeterReadings
                .Include(r => r.MeterSerialNoNavigation) // 👈 Include meter to access ConsumerId
                .Where(r => r.MeterSerialNo == meterSerialNo)
                .OrderBy(r => r.ReadingDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<MeterReading>> GetByDateRangeAsync(string meterSerialNo, DateTime startDate, DateTime endDate)
        {
            return await _context.MeterReadings
                .Include(r => r.MeterSerialNoNavigation) // 👈 Include meter here too
                .Where(r => r.MeterSerialNo == meterSerialNo &&
                            r.ReadingDate >= startDate &&
                            r.ReadingDate <= endDate)
                .OrderBy(r => r.ReadingDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<MeterReading>> GetAllWithMetersAsync()
        {
            return await _context.MeterReadings
                .Include(r => r.MeterSerialNoNavigation) // 👈 Include meter for global fetch too
                .OrderBy(r => r.MeterSerialNo)
                .ToListAsync();
        }

        public async Task AddBulkAsync(IEnumerable<MeterReading> readings)
        {
            await _context.MeterReadings.AddRangeAsync(readings);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
