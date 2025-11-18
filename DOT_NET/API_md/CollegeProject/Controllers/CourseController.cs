using CollegeProject.Interfaces;
using CollegeProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;

        public CourseController(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }

        
        [HttpGet]
        
    
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseRepo.GetAllCoursesAsync();
            return Ok(courses);
        }

       
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseRepo.GetCourseByIdAsync(id);
            if (course == null)
                return NotFound(new { message = "Course not found" });
            return Ok(course);
        }

        
        [HttpPost]
        
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _courseRepo.AddCourseAsync(course);
            return Ok(new { message = "Course added successfully" });
        }

        
        [HttpPut("{id}")]
       
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
        {
            if (id != course.CourseId)
                return BadRequest("Course ID mismatch");

            var result = await _courseRepo.UpdateCourseAsync(course);
            if (!result)
                return NotFound(new { message = "Course not found" });

            return Ok(new { message = "Course updated successfully" });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _courseRepo.GetCourseByIdAsync(id); // Make sure to include Students

            if (course == null)
                return NotFound(new { message = "Course not found" });

            if (course.Students.Any())
                return BadRequest(new { message = "Cannot delete course. Students are assigned to this course." });

            var result = await _courseRepo.DeleteCourseAsync(id);
            if (!result)
                return NotFound(new { message = "Course not found" });

            return Ok(new { message = "Course deleted successfully" });
        }

    }
}
