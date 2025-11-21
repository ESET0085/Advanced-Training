using AMI_Project_Backend.DTOs;
using AMI_Project_Backend.Models;

namespace AMI_Project_Backend.Interfaces
{
    public interface IDataRepository
    {
        List<MeterDto> GetAllMeters();
        List<MeterReadingDto> GetMeterReadings(string meterSerialNo, DateTime periodStart, DateTime periodEnd);
        ConsumerDto? GetConsumerById(long consumerId);
        TariffDto? GetTariffById(int tariffId);
        List<TariffSlabDto> GetTariffSlabs(int tariffId);
        void SaveBills(List<BillingDto> bills);
        List<BillingDto> GetAllBills();
    }
}
