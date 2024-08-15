using System.Collections.Generic;
using System.Threading.Tasks;
using StudentTable.DTO;
using StudentTable.Model;

namespace StudentTable.Repositories
{
    public interface IStudentCourseRepository
    {
        Task<IEnumerable<StudentCourseDto>> GetStudentCoursesAsync();
        Task<StudentCourseDto> GetStudentCourseAsync(int id);
        Task<StudentCourseDto> AddStudentCourseAsync(StudentCourseDto studentCourseDto);
        Task<StudentCourseDto> UpdateStudentCourseAsync(int id, StudentCourseDto studentCourseDto);
        Task<bool> DeleteStudentCourseAsync(int id);
        Task<bool> StudentCourseExistsAsync(int id);
    }
}
