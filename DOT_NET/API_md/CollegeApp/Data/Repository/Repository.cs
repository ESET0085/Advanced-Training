
using Microsoft.EntityFrameworkCore;

namespace College_App.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CollegeDBContext _context;
        public Repository(CollegeDBContext context)
        {
            _context = context;
        }
        public async Task<T> getElementById(int id)
        {
            var element= await _context.Set < T >().FindAsync(id);
            return element;
        }

    }
}
