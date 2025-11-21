using AMI_Project_Backend.Models;

namespace AMI_Project_Backend.Interfaces
{
    public interface ITariffRepository
    {
        Task<IEnumerable<Tariff>> GetAllAsync();
        Task<Tariff?> GetByIdAsync(int id);
        Task<Tariff> AddAsync(Tariff tariff);
        Task<Tariff?> UpdateAsync(Tariff tariff);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TariffSlab>> GetSlabsByTariffIdAsync(int tariffId);
    }
}
