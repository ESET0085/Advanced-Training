using AMI_Project_Backend.Data;
using AMI_Project_Backend.Interfaces;
using AMI_Project_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace AMI_Project_Backend.Repositories
{
    public class ConsumerRepository : Repository<Consumer>, IConsumerRepository
    {
        public ConsumerRepository(AMIDbContext context) : base(context) { }

        public async Task<IEnumerable<Consumer>> GetByOrgUnitAsync(int orgUnitId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(c => c.OrgUnitId == orgUnitId)
                .ToListAsync();
        }

        public async Task<Consumer?> GetWithMeterAsync(long consumerId)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(c => c.Meters) 
                .FirstOrDefaultAsync(c => c.ConsumerId == consumerId);
        }
    }
}
