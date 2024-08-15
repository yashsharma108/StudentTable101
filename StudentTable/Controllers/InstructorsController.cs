using Microsoft.AspNetCore.Mvc;
using StudentTable.DTO;
using StudentTable.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorsController(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorDto>>> GetInstructors()
        {
            var instructors = await _instructorRepository.GetInstructorsAsync();
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorDto>> GetInstructor(int id)
        {
            var instructor = await _instructorRepository.GetInstructorAsync(id);

            if (instructor == null)
            {
                return NotFound();
            }

            return Ok(instructor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstructor(int id, InstructorDto instructorDto)
        {
            if (id != instructorDto.InstructorId)
            {
                return BadRequest();
            }

            var updatedInstructor = await _instructorRepository.UpdateInstructorAsync(id, instructorDto);

            if (updatedInstructor == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<InstructorDto>> PostInstructor(InstructorDto instructorDto)
        {
            var newInstructor = await _instructorRepository.AddInstructorAsync(instructorDto);

            return CreatedAtAction(nameof(GetInstructor), new { id = newInstructor.InstructorId }, newInstructor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            var deleted = await _instructorRepository.DeleteInstructorAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
