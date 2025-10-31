﻿using CollegeProject.Interfaces;
using CollegeProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;

        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        
        [HttpGet]
        
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepo.GetAllStudentsAsync();
            return Ok(students);
        }

        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentRepo.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound(new { message = "Student not found" });
            return Ok(student);
        }

        [HttpPost]
        
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _studentRepo.AddStudentAsync(student);
            return Ok(new { message = "Student added successfully" });
        }

        
        [HttpPut("{id}")]
        
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            if (id != student.StudentId)
                return BadRequest("Student ID mismatch");

            var result = await _studentRepo.UpdateStudentAsync(student);
            if (!result)
                return NotFound(new { message = "Student not found" });

            return Ok(new { message = "Student updated successfully" });
        }

        
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentRepo.DeleteStudentAsync(id);
            if (!result)
                return NotFound(new { message = "Student not found" });

            return Ok(new { message = "Student deleted successfully" });
        }

        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<Student>> GetStudentByName(string name)
        {
            var student = await _studentRepo.GetStudentByNameAsync(name);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

    }
}
