using AMI_Project_Backend.Models;

namespace AMI_Project_Backend.Interfaces
{
    public interface IConsumerRepository : IRepository<Consumer>
    {
        Task<IEnumerable<Consumer>> GetByOrgUnitAsync(int orgUnitId);
        Task<Consumer?> GetWithMeterAsync(long consumerId);
    }
}
