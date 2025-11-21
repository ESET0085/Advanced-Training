using AMI_Project_Backend.Models;

namespace AMI_Project_Backend.Interfaces
{
    public interface IMeterReadingRepository : IRepository<MeterReading>
    {
        Task<IEnumerable<MeterReading>> GetByMeterSerialNoAsync(string meterSerialNo);
        Task<IEnumerable<MeterReading>> GetByDateRangeAsync(string meterSerialNo, DateTime startDate, DateTime endDate);
        Task<IEnumerable<MeterReading>> GetAllWithMetersAsync(); // 👈 Added this method
        Task AddBulkAsync(IEnumerable<MeterReading> readings);
        Task SaveChangesAsync();
    }
}
