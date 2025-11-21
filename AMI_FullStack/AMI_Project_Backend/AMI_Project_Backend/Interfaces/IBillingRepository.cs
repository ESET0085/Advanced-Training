using AMI_Project_Backend.Models;

namespace AMI_Project_Backend.Interfaces
{
    public interface IBillingRepository : IRepository<Billing>
    {
        
        Task<IEnumerable<Billing>> GetByConsumerAsync(long consumerId);

        
        Task<IEnumerable<Billing>> GetByPeriodAsync(DateTime periodStart, DateTime periodEnd);

        
        Task<IEnumerable<Billing>> GetByMeterAsync(string meterSerialNo);
    }
}
