using Microsoft.AspNetCore.Mvc;
using StudentTable.DTO;
using StudentTable.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await _studentRepository.GetStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await _studentRepository.GetStudentAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentDto studentDto)
        {
            if (id != studentDto.StudentID)
            {
                return BadRequest();
            }

            var updatedStudent = await _studentRepository.UpdateStudentAsync(id, studentDto);

            if (updatedStudent == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> PostStudent(StudentDto studentDto)
        {
            var newStudent = await _studentRepository.AddStudentAsync(studentDto);

            return CreatedAtAction(nameof(GetStudent), new { id = newStudent.StudentID }, newStudent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _studentRepository.DeleteStudentAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
