using System.Collections.Generic;
using System.Threading.Tasks;
using StudentTable.DTO;

namespace StudentTable.Repositories
{
    public interface IInstructorRepository
    {
        Task<IEnumerable<InstructorDto>> GetInstructorsAsync();
        Task<InstructorDto> GetInstructorAsync(int id);
        Task<InstructorDto> AddInstructorAsync(InstructorDto instructorDto);
        Task<InstructorDto> UpdateInstructorAsync(int id, InstructorDto instructorDto);
        Task<bool> DeleteInstructorAsync(int id);
        Task<bool> InstructorExistsAsync(int id);
    }
}
