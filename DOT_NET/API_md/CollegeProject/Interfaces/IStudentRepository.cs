using System.Collections.Generic;
using System.Threading.Tasks;
using CollegeProject.Models;

namespace CollegeProject.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task AddStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int id);
        Task<Student> GetStudentByNameAsync(string name);

    }
}
