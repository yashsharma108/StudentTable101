using Microsoft.EntityFrameworkCore;
using StudentTable.Data;
using StudentTable.DTO;
using StudentTable.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTable.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly SchoolDbContext _context;

        public InstructorRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InstructorDto>> GetInstructorsAsync()
        {
            return await _context.Instructors
                .Select(i => new InstructorDto
                {
                    InstructorId = i.InstructorId,
                    LastName = i.LastName,
                    FirstName = i.FirstName,
                    Status = i.Status,
                    HireDate = i.HireDate,
                    AnnualSalary = i.AnnualSalary,
                    DepartmentId = i.DepartmentId
                })
                .ToListAsync();
        }

        public async Task<InstructorDto> GetInstructorAsync(int id)
        {
            return await _context.Instructors
                .Where(i => i.InstructorId == id)
                .Select(i => new InstructorDto
                {
                    InstructorId = i.InstructorId,
                    LastName = i.LastName,
                    FirstName = i.FirstName,
                    Status = i.Status,
                    HireDate = i.HireDate,
                    AnnualSalary = i.AnnualSalary,
                    DepartmentId = i.DepartmentId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<InstructorDto> AddInstructorAsync(InstructorDto instructorDto)
        {
            var instructor = new Instructors
            {
                LastName = instructorDto.LastName,
                FirstName = instructorDto.FirstName,
                Status = instructorDto.Status,
                HireDate = instructorDto.HireDate,
                AnnualSalary = instructorDto.AnnualSalary,
                DepartmentId = instructorDto.DepartmentId
            };

            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();

            instructorDto.InstructorId = instructor.InstructorId;

            return instructorDto;
        }

        public async Task<InstructorDto> UpdateInstructorAsync(int id, InstructorDto instructorDto)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return null;
            }

            instructor.LastName = instructorDto.LastName;
            instructor.FirstName = instructorDto.FirstName;
            instructor.Status = instructorDto.Status;
            instructor.HireDate = instructorDto.HireDate;
            instructor.AnnualSalary = instructorDto.AnnualSalary;
            instructor.DepartmentId = instructorDto.DepartmentId;

            _context.Entry(instructor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await InstructorExistsAsync(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return instructorDto;
        }

        public async Task<bool> DeleteInstructorAsync(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return false;
            }

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> InstructorExistsAsync(int id)
        {
            return await _context.Instructors.AnyAsync(e => e.InstructorId == id);
        }
    }
}
