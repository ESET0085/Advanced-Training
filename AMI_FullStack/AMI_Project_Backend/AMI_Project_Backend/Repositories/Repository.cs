using AMI_Project_Backend.Data;
using AMI_Project_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AMI_Project_Backend.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AMIDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(AMIDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.AsNoTracking().ToListAsync();

        public async Task<T?> GetByIdAsync(object id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
