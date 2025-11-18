using College_App.Data;

public interface IStudentRepository
{
    public   Task<IEnumerable<Student>>GetAllStudents();

    public Task<Student> GetStudentById(int id);  
    

}
