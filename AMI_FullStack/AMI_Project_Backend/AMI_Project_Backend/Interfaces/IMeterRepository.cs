using AMI_Project_Backend.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMI_Project_Backend.Interfaces
{
    public interface IMeterRepository : IRepository<Meter>
    {
        Task<Meter?> GetBySerialAsync(string meterSerialNo);

        Task<IEnumerable<Meter>> GetByConsumerAsync(long consumerId);

        Task<bool> ExistsAsync(string meterSerialNo);

        Task<IEnumerable<MeterReading>> GetReadingsAsync(string meterSerialNo, DateTime periodStart, DateTime periodEnd);

        Task<IEnumerable<Meter>> FindByConsumerIdAsync(long consumerId);


        // ---- NEW METHODS required by the controller ----

        Task<bool> ExistsIpAsync(string ipAddress);
        Task<bool> ExistsIpAsync(string ipAddress, string excludeSerialNo);

        Task<bool> ExistsIccidAsync(string iccid);
        Task<bool> ExistsIccidAsync(string iccid, string excludeSerialNo);

        Task<bool> ExistsImsiAsync(string imsi);
        Task<bool> ExistsImsiAsync(string imsi, string excludeSerialNo);

        // In your IMeterRepository interface, make sure you have:
        //Task<bool> ExistsIccidAsync(string iccid, string excludeSerialNo = null);
        //Task<bool> ExistsIpAsync(string ipAddress, string excludeSerialNo = null);
        //Task<bool> ExistsImsiAsync(string imsi, string excludeSerialNo = null);
    }
}
