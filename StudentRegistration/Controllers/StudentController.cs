using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Models;
using StudentRegistration.Service;

namespace StudentRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto dto)
        {
            if(dto.DateOfBirth > DateOnly.FromDateTime(DateTime.Now))
            {
                return BadRequest("Date of Birth cannot be in the future.");
            }

            if(dto.DateOfBirth < DateOnly.FromDateTime(DateTime.Now.AddYears(-100)))
            {
                return BadRequest("Date of Birth cannot be more than 100 years ago.");
            }

            var createdStudent = await _studentService.AddStudentAsync(dto);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.StudentID }, createdStudent);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] Student student)
        {

            if (id != student.StudentID)
            {
                return BadRequest();
            }
            var result = await _studentService.UpdateStudentAsync(student);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var result = await _studentService.DeleteStudentAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
