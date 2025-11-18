using College_App.Data;
using Microsoft.EntityFrameworkCore;

namespace College_App.Data.Repository

{
    public class StudentRepository : IStudentRepository
    {
        private readonly CollegeDBContext _context;
        public StudentRepository(CollegeDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _context.Students.Where(s => s.studentID == id).FirstOrDefaultAsync();
            return student;
        }







    }
}
