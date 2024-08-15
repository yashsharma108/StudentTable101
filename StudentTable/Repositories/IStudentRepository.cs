using System.Collections.Generic;
using System.Threading.Tasks;
using StudentTable.DTO;
using StudentTable.Model;

namespace StudentTable.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentDto>> GetStudentsAsync();
        Task<StudentDto> GetStudentAsync(int id);
        Task<StudentDto> AddStudentAsync(StudentDto studentDto);
        Task<StudentDto> UpdateStudentAsync(int id, StudentDto studentDto);
        Task<bool> DeleteStudentAsync(int id);
        Task<bool> StudentExistsAsync(int id);
    }
}
