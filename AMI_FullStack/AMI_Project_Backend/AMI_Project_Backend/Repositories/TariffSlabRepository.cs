using AMI_Project_Backend.Data;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace AMI_Project_Backend.Repositories
{
    public class TariffSlabRepository : Repository<TariffSlab>, ITariffSlabRepository
    {
        private readonly AMIDbContext _context;

        public TariffSlabRepository(AMIDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TariffSlab>> GetByTariffIdAsync(int tariffId)
        {
            return await _context.TariffSlabs
                .Where(t => t.TariffId == tariffId)
                .OrderBy(t => t.FromKwh)
                .ToListAsync();
        }
    }
}
