using Microsoft.EntityFrameworkCore;
using StudentTable.Data;
using StudentTable.DTO;
using StudentTable.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTable.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            return await _context.Students
                .Select(s => new StudentDto
                {
                    StudentID = s.StudentID,
                    StudentNumber = s.StudentNumber,
                    LastName = s.LastName,
                    FirstName = s.FirstName,
                    EnrollmentDate = s.EnrollmentDate,
                    GraduationDate = s.GraduationDate
                })
                .ToListAsync();
        }

        public async Task<StudentDto> GetStudentAsync(int id)
        {
            return await _context.Students
                .Where(s => s.StudentID == id)
                .Select(s => new StudentDto
                {
                    StudentID = s.StudentID,
                    StudentNumber = s.StudentNumber,
                    LastName = s.LastName,
                    FirstName = s.FirstName,
                    EnrollmentDate = s.EnrollmentDate,
                    GraduationDate = s.GraduationDate
                })
                .FirstOrDefaultAsync();
        }

        public async Task<StudentDto> AddStudentAsync(StudentDto studentDto)
        {
            var student = new Students
            {
                StudentNumber = studentDto.StudentNumber,
                LastName = studentDto.LastName,
                FirstName = studentDto.FirstName,
                EnrollmentDate = studentDto.EnrollmentDate,
                GraduationDate = studentDto.GraduationDate
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            studentDto.StudentID = student.StudentID;

            return studentDto;
        }

        public async Task<StudentDto> UpdateStudentAsync(int id, StudentDto studentDto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }

            student.StudentNumber = studentDto.StudentNumber;
            student.LastName = studentDto.LastName;
            student.FirstName = studentDto.FirstName;
            student.EnrollmentDate = studentDto.EnrollmentDate;
            student.GraduationDate = studentDto.GraduationDate;

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await StudentExistsAsync(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return studentDto;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return false;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> StudentExistsAsync(int id)
        {
            return await _context.Students.AnyAsync(e => e.StudentID == id);
        }
    }
}
