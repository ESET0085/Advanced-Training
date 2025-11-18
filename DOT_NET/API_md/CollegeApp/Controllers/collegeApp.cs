using College_App.Data;
using College_App.Data.Repository;
using College_App.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace College_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class collegeApp : ControllerBase
    {
        private readonly IRepository<Student> _IRepositoryStudent;
        private readonly IRepository<Course> _IRepositoryCourse;

        public collegeApp(
    IRepository<Student> studentRepository,
    IRepository<Course> courseRepository)
        {
            _IRepositoryStudent = studentRepository;
            _IRepositoryCourse = courseRepository;
        }


        [HttpGet("GetGenericStudent")]
        public async Task<Student> GetStudentById(int id)
        {
            return await _IRepositoryStudent.getElementById(id);
        }


        [HttpGet("GetGenericCourse")]
        public async Task<Course> GetCourseById(int id)
        {
            return await _IRepositoryCourse.getElementById(id);
        }

        //public async Task<ActionResult<IEnumerable<StudentDTO>>> getstudents()
        //{
        //    var studentsList = await _dbContext.Students.ToListAsync();
        //    var students =_dbContext.Students.Select(s => new StudentDTO()
        //    {
        //        studentID = s.studentID,
        //        name = s.name,
        //        age = s.age,
        //        email = s.email,


        //    }).ToListAsync();

        //    return Ok(students);
        //}







        ////[HttpGet]
        ////public IEnumerable<Student> getStudents()
        ////{
        ////    return collegeRepository.students;
        ////}

        //// FIX: Remove duplicate/conflicting route attributes for "{id:Int}"
        //// Only keep one method with [HttpGet("{id:int}", Name = "getstudentbyid")]


        //[HttpGet("{id:int}", Name = "getstudentbyid")]
        //public ActionResult<Student> getstudentbyid(int id)
        //{
        //    if (id == 0)
        //    {
        //        return BadRequest();
        //    }

        //    var student = _dbContext.Students.FirstOrDefault(n => n.studentID == id);

        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(student);
        //}


        //// [HttpGet("{id:Int}", Name = "getstudentsbyid")]
        //// public Student getStudent(int id)
        //// {
        ////     return collegeRepository.students.Where(n => n.studentID == id).First();
        //// }



        //// [HttpGet("{id}",Name = "getstudentsbyid")]
        //// public Student getstudentsbyid(int id)
        //// {
        ////     return collegeRepository.students.Where(n=> n.studentID == id).First();
        //// }


        //[HttpGet("{Name:alpha}", Name = "getstudentsbyname")]
        //public Student getstudentsbyname(string Name)
        //{
        //    return _dbContext.Students.Where(n => n.name == Name).First();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteStudent(int id)
        //{
        //    var student = _dbContext.Students.FirstOrDefault(s => s.studentID == id);

        //    if (student == null)
        //    {
        //        return NotFound(); // 404 if not found
        //    }

        //    _dbContext.Students.Remove(student);
        //    _dbContext.SaveChanges();

        //    return NoContent(); // 204 on successful deletion, no content returned
        //}





        ////[HttpGet]
        ////public ActionResult<Student> getstudentbyname(string Name)
        ////{
        ////    if (string.IsNullOrEmpty(Name))
        ////    {
        ////        return BadRequest();
        ////    }

        ////    var student = collegeRepository.students.Where(n => n.name == Name).First();

        ////    if (student == null)
        ////    {
        ////        return NotFound();
        ////    }

        ////    return Ok(student);


        ////}


        //[HttpGet]
        //[Route("All")]
        //public async  Task<ActionResult<IEnumerable<StudentDTO>>> getStudents()
        //{
        //    var students =  _dbContext.Students.Select(s => new StudentDTO()
        //    {
        //        //studentID= s.studentID,
        //        name = s.name,
        //        age = s.age,
        //        email = s.email
        //    });

        //    return Ok(students);
        //}

        //[HttpGet("{id:int}", Name = "getstudentbyid")]
        //public async Task< ActionResult<StudentDTO>> getstudentbyid(int id)
        //{
        //    if (id == 0)
        //    {
        //        return BadRequest();
        //    }
        //    var student =await  _dbContext.Students.Where(n => n.studentID == id).FirstAsync();

        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    var studentDTO = new StudentDTO()
        //    {
        //        //studentID = student.studentID,
        //        name = student.name,
        //        age = student.age,
        //        email = student.email
        //    };
        //    return Ok(studentDTO);
        //}

        //[HttpPost("Create")]

        //public  ActionResult<Student> Createstudent([FromBody] Student Student)
        //{
        //    if (Student == null)
        //    {
        //        return BadRequest();
        //    }


        //    var newStudent = new Student()
        //    {
        //        //studentID = collegeRepository.students.Max(s => s.studentID) + 1, // Auto-generate ID
        //        name = Student.name,
        //        age = Student.age,
        //        email = Student.email
        //    };
        //    _dbContext.Students.Add(newStudent);
        //    _dbContext.SaveChanges();
        //    // Return the created student with a 201 status code
        //    return Ok(newStudent);
        //}


        //[HttpPut]
        //[Route("Update")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]


        //public ActionResult Updatestudent(int id, [FromBody] Student student)
        //{



        //    if (student == null || id == 0)
        //    {
        //        return BadRequest();
        //    }
        //    var existingStudent = _dbContext.Students.FirstOrDefault(s => s.studentID == id);
        //    if (existingStudent == null)
        //    {
        //        return NotFound();
        //    }
        //    // Update the existing student's properties
        //    existingStudent.name = student.name;
        //    existingStudent.age = student.age;
        //    existingStudent.email = student.email;
        //    //_dbContext.SaveChanges();
        //    return NoContent(); // Standard response for successful PUT without returning data
        //}



        ////public ActionResult UpdateStudent(int id, [FromBody] Student student)
        ////{
        ////    if (student == null || id == 0 || id != student.studentID)
        ////    {
        ////        return BadRequest();
        ////    }

        ////    var existingStudent = _dbContext.Students.Find(id);
        ////    if (existingStudent == null)
        ////    {
        ////        return NotFound();
        ////    }

        ////    // Update the existing entity properties
        ////    existingStudent.name = student.name;
        ////    existingStudent.age = student.age;
        ////    existingStudent.email = student.email;

        ////    _dbContext.SaveChanges();

        ////    return NoContent();
        ////}




        //[HttpPatch]
        //[Route("UpdatePartial")]
        //public ActionResult PartiallyUpdatestudent(int id, [FromBody] JsonPatchDocument<StudentDTO> studentDTO)
        //{
        //    if (studentDTO == null || id == 0)
        //    {
        //        return BadRequest();
        //    }

        //    var existingStudent = _dbContext.Students.FirstOrDefault(s => s.studentID == id);
        //    if (existingStudent == null)
        //    {
        //        return NotFound();
        //    }

        //    var studentToPatch = new StudentDTO()
        //    {
        //        //studentID = existingStudent.studentID,
        //        name = existingStudent.name,
        //        age = existingStudent.age,
        //        email = existingStudent.email
        //    };
        //    studentDTO.ApplyTo(studentToPatch, ModelState);
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    // Update the existing student's properties
        //    existingStudent.name = studentToPatch.name;
        //    existingStudent.age = studentToPatch.age;
        //    existingStudent.email = studentToPatch.email;
        //    _dbContext.SaveChanges();
        //    return NoContent();


        //}






    }
}

