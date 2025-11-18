using AMI_Project.Models;



namespace AMI_Project_API.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<OrgUnit> OrgUnits { get; }
        IGenericRepository<Tariff> Tariffs { get; }
        IGenericRepository<TariffSlab> TariffSlabs { get; }
        IGenericRepository<Consumer> Consumers { get; }
        IGenericRepository<Meter> Meters { get; }
        //IGenericRepository<MeterReading> MeterReadings { get; }
        IGenericRepository<Billing> Billings { get; }

        Task<int> SaveAsync();
    }
}
