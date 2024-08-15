using Microsoft.AspNetCore.Mvc;
using StudentTable.DTO;
using StudentTable.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _repository;

        public CoursesController(ICourseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            var courses = await _repository.GetCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourse(int id)
        {
            var course = await _repository.GetCourseAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, CourseDto courseDto)
        {
            if (id != courseDto.CourseID)
            {
                return BadRequest();
            }

            var updatedCourse = await _repository.UpdateCourseAsync(id, courseDto);
            if (updatedCourse == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> PostCourse(CourseDto courseDto)
        {
            var createdCourse = await _repository.AddCourseAsync(courseDto);
            return CreatedAtAction(nameof(GetCourse), new { id = createdCourse.CourseID }, createdCourse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var deleted = await _repository.DeleteCourseAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
