using AMI_Project_Backend.Data;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace AMI_Project_Backend.Repositories
{
    public class OrgUnitRepository : IOrgUnitRepository
    {
        private readonly AMIDbContext _context;

        public OrgUnitRepository(AMIDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrgUnit>> GetAllAsync()
        {
            return await _context.OrgUnits
                .Include(o => o.Children)
                .ToListAsync();
        }

        public async Task<OrgUnit?> GetByIdAsync(int id)
        {
            return await _context.OrgUnits
                .Include(o => o.Children)
                .FirstOrDefaultAsync(o => o.OrgUnitId == id);
        }

        public async Task AddAsync(OrgUnit orgUnit)
        {
            await _context.OrgUnits.AddAsync(orgUnit);
        }

        public async Task UpdateAsync(OrgUnit orgUnit)
        {
            _context.OrgUnits.Update(orgUnit);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var orgUnit = await _context.OrgUnits.FindAsync(id);
            if (orgUnit != null)
            {
                _context.OrgUnits.Remove(orgUnit);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
