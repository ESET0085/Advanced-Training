using Microsoft.AspNetCore.Mvc;

namespace students_database.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CollegeController : ControllerBase


    {
        private readonly Models.CollegeContext _context;
        public CollegeController(Models.CollegeContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetStudents")]
        
        public IEnumerable<Models.Student> GetStudents()
        {
            return _context.Students;
        }

        [HttpPost(Name = "AddStudent")]
        public IActionResult AddStudent(Models.Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetStudents), new { id = student.StudentId }, student);
        }





    }
}
