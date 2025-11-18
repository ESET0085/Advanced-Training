using AMI_Project.Data;
using AMI_Project.Models;
using AMI_Project_API.Interfaces;

namespace AMI_Project_API.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AMIDbContext _context;

        public IGenericRepository<User> Users { get; private set; }
        public IGenericRepository<OrgUnit> OrgUnits { get; private set; }
        public IGenericRepository<Tariff> Tariffs { get; private set; }
        public IGenericRepository<TariffSlab> TariffSlabs { get; private set; }
        public IGenericRepository<Consumer> Consumers { get; private set; }
        public IGenericRepository<Meter> Meters { get; private set; }
        //public IGenericRepository<MeterReading> MeterReadings { get; private set; }
        public IGenericRepository<Billing> Billings { get; private set; }

        public UnitOfWork(AMIDbContext context)
        {
            _context = context;

            Users = new GenericRepository<User>(_context);
            OrgUnits = new GenericRepository<OrgUnit>(_context);
            Tariffs = new GenericRepository<Tariff>(_context);
            TariffSlabs = new GenericRepository<TariffSlab>(_context);
            Consumers = new GenericRepository<Consumer>(_context);
            Meters = new GenericRepository<Meter>(_context);
            //MeterReadings = new GenericRepository<MeterReading>(_context);
            Billings = new GenericRepository<Billing>(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
