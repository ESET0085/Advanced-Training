using AMI_Project_Backend.Models;

namespace AMI_Project_Backend.Interfaces
{
    public interface IOrgUnitRepository
    {
        Task<IEnumerable<OrgUnit>> GetAllAsync();
        Task<OrgUnit?> GetByIdAsync(int id);
        Task AddAsync(OrgUnit orgUnit);
        Task UpdateAsync(OrgUnit orgUnit);
        Task DeleteAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
