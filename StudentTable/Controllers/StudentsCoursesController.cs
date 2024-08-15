using Microsoft.AspNetCore.Mvc;
using StudentTable.DTO;
using StudentTable.Model;
using StudentTable.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        private readonly IStudentCourseRepository _repository;

        public StudentCoursesController(IStudentCourseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentCourseDto>>> GetStudentCourses()
        {
            var studentCourses = await _repository.GetStudentCoursesAsync();
            return Ok(studentCourses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentCourseDto>> GetStudentCourse(int id)
        {
            var studentCourse = await _repository.GetStudentCourseAsync(id);

            if (studentCourse == null)
            {
                return NotFound();
            }

            return Ok(studentCourse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentCourse(int id, StudentCourseDto studentCourseDto)
        {
            if (id != studentCourseDto.StudentCourseId)
            {
                return BadRequest();
            }

            var updatedStudentCourse = await _repository.UpdateStudentCourseAsync(id, studentCourseDto);

            if (updatedStudentCourse == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<StudentCourseDto>> PostStudentCourse(StudentCourseDto studentCourseDto)
        {
            var createdStudentCourse = await _repository.AddStudentCourseAsync(studentCourseDto);

            return CreatedAtAction(nameof(GetStudentCourse), new { id = createdStudentCourse.StudentCourseId }, createdStudentCourse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentCourse(int id)
        {
            var deleted = await _repository.DeleteStudentCourseAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
