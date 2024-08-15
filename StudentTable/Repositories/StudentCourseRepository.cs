using Microsoft.EntityFrameworkCore;
using StudentTable.Data;
using StudentTable.DTO;
using StudentTable.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTable.Repositories
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly SchoolDbContext _context;

        public StudentCourseRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentCourseDto>> GetStudentCoursesAsync()
        {
            return await _context.StudentCourses
                .Select(sc => new StudentCourseDto
                {
                    StudentCourseId = sc.StudentCourseId,
                    StudentId = sc.StudentId,
                    CourseId = sc.CourseId
                })
                .ToListAsync();
        }

        public async Task<StudentCourseDto> GetStudentCourseAsync(int id)
        {
            return await _context.StudentCourses
                .Where(sc => sc.StudentCourseId == id)
                .Select(sc => new StudentCourseDto
                {
                    StudentCourseId = sc.StudentCourseId,
                    StudentId = sc.StudentId,
                    CourseId = sc.CourseId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<StudentCourseDto> AddStudentCourseAsync(StudentCourseDto studentCourseDto)
        {
            var studentCourse = new StudentCourses
            {
                StudentId = studentCourseDto.StudentId,
                CourseId = studentCourseDto.CourseId
            };

            _context.StudentCourses.Add(studentCourse);
            await _context.SaveChangesAsync();

            studentCourseDto.StudentCourseId = studentCourse.StudentCourseId;

            return studentCourseDto;
        }

        public async Task<StudentCourseDto> UpdateStudentCourseAsync(int id, StudentCourseDto studentCourseDto)
        {
            var studentCourse = await _context.StudentCourses.FindAsync(id);
            if (studentCourse == null)
            {
                return null;
            }

            studentCourse.StudentId = studentCourseDto.StudentId;
            studentCourse.CourseId = studentCourseDto.CourseId;

            _context.Entry(studentCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await StudentCourseExistsAsync(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return studentCourseDto;
        }

        public async Task<bool> DeleteStudentCourseAsync(int id)
        {
            var studentCourse = await _context.StudentCourses.FindAsync(id);
            if (studentCourse == null)
            {
                return false;
            }

            _context.StudentCourses.Remove(studentCourse);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> StudentCourseExistsAsync(int id)
        {
            return await _context.StudentCourses.AnyAsync(e => e.StudentCourseId == id);
        }
    }
}
