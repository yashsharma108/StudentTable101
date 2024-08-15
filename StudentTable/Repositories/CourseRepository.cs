using Microsoft.EntityFrameworkCore;
using StudentTable.Data;
using StudentTable.DTO;
using StudentTable.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTable.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolDbContext _context;

        public CourseRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesAsync()
        {
            return await _context.Courses
                .Select(c => new CourseDto
                {
                    CourseID = c.CourseID,
                    CourseName = c.CourseName,
                    CourseNumber = c.CourseNumber,
                    CourseDescription = c.CourseDescription,
                    CourseUnits = c.CourseUnits,
                    DepartmentId = c.DepartmentId,
                    InstructorID = c.InstructorID
                })
                .ToListAsync();
        }

        public async Task<CourseDto> GetCourseAsync(int id)
        {
            try
            {
                return await _context.Courses
                    .Where(c => c.CourseID == id)
                    .Select(c => new CourseDto
                    {
                        CourseID = c.CourseID,
                        CourseName = c.CourseName,
                        CourseNumber = c.CourseNumber,
                        CourseDescription = c.CourseDescription,
                        CourseUnits = c.CourseUnits,
                        DepartmentId = c.DepartmentId,
                        InstructorID = c.InstructorID
                    }).FirstOrDefaultAsync();
            }
            catch (Exception ex) {
                throw;
            }


        }

        public async Task<CourseDto> AddCourseAsync(CourseDto courseDto)
        {
            var course = new Courses
            {
                CourseName = courseDto.CourseName,
                CourseNumber = courseDto.CourseNumber,
                CourseDescription = courseDto.CourseDescription,
                CourseUnits = courseDto.CourseUnits,
                DepartmentId = courseDto.DepartmentId,
                InstructorID = courseDto.InstructorID
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            courseDto.CourseID = course.CourseID;
            return courseDto;
        }

        public async Task<CourseDto> UpdateCourseAsync(int id, CourseDto courseDto)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return null;
            }

            course.CourseName = courseDto.CourseName;
            course.CourseNumber = courseDto.CourseNumber;
            course.CourseDescription = courseDto.CourseDescription;
            course.CourseUnits = courseDto.CourseUnits;
            course.DepartmentId = courseDto.DepartmentId;
            course.InstructorID = courseDto.InstructorID;

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CourseExistsAsync(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return courseDto;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return false;
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CourseExistsAsync(int id)
        {
            return await _context.Courses.AnyAsync(e => e.CourseID == id);
        }
    }
}
