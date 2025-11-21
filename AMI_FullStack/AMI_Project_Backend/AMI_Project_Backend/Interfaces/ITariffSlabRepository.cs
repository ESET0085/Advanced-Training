using AMI_Project_Backend.Models;

namespace AMI_Project_Backend.Interfaces
{
    public interface ITariffSlabRepository : IRepository<TariffSlab>
    {
        Task<IEnumerable<TariffSlab>> GetByTariffIdAsync(int tariffId);
    }
}
