using CollegeProject.Interfaces;
using CollegeProject.Models;
using Microsoft.EntityFrameworkCore;


namespace CollegeProject.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CollegeDbContext _context;

        public StudentRepository(CollegeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            var existing = await _context.Students.FindAsync(student.StudentId);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Student> GetStudentByNameAsync(string name)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower());
        }

    }
}
