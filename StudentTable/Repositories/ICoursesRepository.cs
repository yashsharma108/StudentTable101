using System.Collections.Generic;
using System.Threading.Tasks;
using StudentTable.DTO;

namespace StudentTable.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseDto>> GetCoursesAsync();
        Task<CourseDto> GetCourseAsync(int id);
        Task<CourseDto> AddCourseAsync(CourseDto courseDto);
        Task<CourseDto> UpdateCourseAsync(int id, CourseDto courseDto);
        Task<bool> DeleteCourseAsync(int id);
        Task<bool> CourseExistsAsync(int id);
    }
}
