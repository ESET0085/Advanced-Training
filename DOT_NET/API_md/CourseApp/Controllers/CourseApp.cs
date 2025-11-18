using CourseApp.Data;
using CourseApp.Data;
using CourseApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseApp : ControllerBase
    {
        private readonly CourseDbContext _context;

        public CourseApp(CourseDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetSql")]

        public ActionResult<IEnumerable<Course>> GetSql()
        {
            var courses = _context.Courses.ToList();
            return Ok(courses);
        }




        [HttpGet("{id}", Name = "GetCourseById")]

        public ActionResult<Course> GetCourseById(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
           _context.SaveChanges();
            return Ok(course);
        }


        [HttpGet("GetByName/{name}")]
        public ActionResult<Course> GetByName(string name)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Name == name);
            if (course == null)
            {
                return NotFound();
            }
            _context.SaveChanges();
            return Ok(course);
        }

        [HttpPost]

        public ActionResult<Course> CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();

            return CreatedAtRoute("GetCourseById", new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }
            var existingCourse = _context.Courses.Find(id);
            if (existingCourse == null)
            {
                return NotFound();
            }
            existingCourse.Name = course.Name;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        [Route("BulkInsert")]
        public ActionResult BulkInsert(List<Course> courses)
        {
            _context.Courses.AddRange(courses);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPatch]
        [Route("Update/{id}")]
        public ActionResult PatchCourse(int id, [FromBody] Course updatedCourse)
        {
            var existingCourse = _context.Courses.Find(id);
            if (existingCourse == null)
            {
                return NotFound($"Course with ID {id} not found.");
            }

           
            if (!string.IsNullOrEmpty(updatedCourse.Name))
                existingCourse.Name = updatedCourse.Name;

           
            

            _context.SaveChanges();
            return Ok(existingCourse);
        }



















    }

}
