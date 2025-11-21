using AMI_Project_Backend.Data;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace AMI_Project_Backend.Repositories
{
    public class MeterRepository : Repository<Meter>, IMeterRepository
    {
        public MeterRepository(AMIDbContext context) : base(context)
        {
        }

        // =======================
        //  BASIC GET METHODS
        // =======================

        public async Task<Meter?> GetBySerialAsync(string meterSerialNo)
        {
            if (string.IsNullOrWhiteSpace(meterSerialNo)) return null;
            var serial = meterSerialNo.Trim();

            return await _dbSet
                .Include(m => m.Consumer)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.MeterSerialNo == serial);
        }

        public async Task<IEnumerable<Meter>> GetByConsumerAsync(long consumerId)
        {
            return await _dbSet
                .Where(m => m.ConsumerId == consumerId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(string meterSerialNo)
        {
            if (string.IsNullOrWhiteSpace(meterSerialNo)) return false;
            var serial = meterSerialNo.Trim();

            return await _dbSet
                .AsNoTracking()
                .AnyAsync(m => m.MeterSerialNo == serial);
        }

        public async Task<IEnumerable<MeterReading>> GetReadingsAsync(string meterSerialNo, DateTime periodStart, DateTime periodEnd)
        {
            if (string.IsNullOrWhiteSpace(meterSerialNo))
                return Enumerable.Empty<MeterReading>();

            return await _context.Set<MeterReading>()
                .Where(r => r.MeterSerialNo == meterSerialNo &&
                            r.ReadingDate >= periodStart &&
                            r.ReadingDate <= periodEnd)
                .OrderBy(r => r.ReadingDate)
                .AsNoTracking()
                .ToListAsync();
        }

        // =======================
        //  DUPLICATE CHECKS
        //  (Matching Controller)
        // =======================

        // --- IP ---
        public async Task<bool> ExistsIpAsync(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress)) return false;
            var ip = ipAddress.Trim();

            return await _dbSet
                .AsNoTracking()
                .AnyAsync(m => m.IpAddress == ip);
        }

        public async Task<bool> ExistsIpAsync(string ipAddress, string excludeSerialNo)
        {
            if (string.IsNullOrWhiteSpace(ipAddress)) return false;
            var ip = ipAddress.Trim();

            return await _dbSet
                .AsNoTracking()
                .AnyAsync(m => m.IpAddress == ip && m.MeterSerialNo != excludeSerialNo);
        }

        // --- ICCID ---
        public async Task<bool> ExistsIccidAsync(string iccid)
        {
            if (string.IsNullOrWhiteSpace(iccid)) return false;
            var id = iccid.Trim();

            return await _dbSet
                .AsNoTracking()
                .AnyAsync(m => m.Iccid == id);
        }

        public async Task<bool> ExistsIccidAsync(string iccid, string excludeSerialNo)
        {
            if (string.IsNullOrWhiteSpace(iccid)) return false;
            var id = iccid.Trim();

            return await _dbSet
                .AsNoTracking()
                .AnyAsync(m => m.Iccid == id && m.MeterSerialNo != excludeSerialNo);
        }

        // --- IMSI ---
        public async Task<bool> ExistsImsiAsync(string imsi)
        {
            if (string.IsNullOrWhiteSpace(imsi)) return false;
            var id = imsi.Trim();

            return await _dbSet
                .AsNoTracking()
                .AnyAsync(m => m.Imsi == id);
        }

        public async Task<bool> ExistsImsiAsync(string imsi, string excludeSerialNo)
        {
            if (string.IsNullOrWhiteSpace(imsi)) return false;
            var id = imsi.Trim();

            return await _dbSet
                .AsNoTracking()
                .AnyAsync(m => m.Imsi == id && m.MeterSerialNo != excludeSerialNo);
        }

        public async Task<IEnumerable<Meter>> FindByConsumerIdAsync(long consumerId)
        {
            return await _context.Meters
                .Where(m => m.ConsumerId == consumerId)
                .ToListAsync();
        }



    }
}
