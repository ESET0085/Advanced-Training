using CollegeProject.Interfaces;
using CollegeProject.Models;
using Microsoft.EntityFrameworkCore;


namespace CollegeProject.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CollegeDbContext _context;

        public CourseRepository(CollegeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task AddCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCourseAsync(Course course)
        {
            var existing = await _context.Courses.FindAsync(course.CourseId);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
