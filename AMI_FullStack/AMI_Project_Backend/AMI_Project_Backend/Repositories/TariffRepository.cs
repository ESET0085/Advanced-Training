using AMI_Project_Backend.Data;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace AMI_Project_Backend.Repositories
{
    public class TariffRepository : ITariffRepository
    {
        private readonly AMIDbContext _context;

        public TariffRepository(AMIDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tariff>> GetAllAsync()
        {
            return await _context.Tariffs.AsNoTracking().ToListAsync();
        }

        public async Task<Tariff?> GetByIdAsync(int id)
        {
            return await _context.Tariffs.FirstOrDefaultAsync(t => t.TariffId == id);
        }

        public async Task<Tariff> AddAsync(Tariff tariff)
        {
            _context.Tariffs.Add(tariff);
            await _context.SaveChangesAsync();
            return tariff;
        }

        public async Task<Tariff?> UpdateAsync(Tariff tariff)
        {
            var existing = await _context.Tariffs.FindAsync(tariff.TariffId);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(tariff);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tariff = await _context.Tariffs.FindAsync(id);
            if (tariff == null) return false;

            _context.Tariffs.Remove(tariff);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                // Throw a custom exception to indicate FK constraint issue
                throw new InvalidOperationException("Cannot delete this tariff because it is linked to other records.");
            }
        }

        public async Task<IEnumerable<TariffSlab>> GetSlabsByTariffIdAsync(int tariffId)
        {
            return await _context.TariffSlabs
                .Where(s => s.TariffId == tariffId)
                .ToListAsync();
        }
    }
}
