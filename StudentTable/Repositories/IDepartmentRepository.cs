using System.Collections.Generic;
using System.Threading.Tasks;
using StudentTable.DTO;

namespace StudentTable.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync();
        Task<DepartmentDto> GetDepartmentAsync(int id);
        Task<DepartmentDto> AddDepartmentAsync(DepartmentDto departmentDto);
        Task<DepartmentDto> UpdateDepartmentAsync(int id, DepartmentDto departmentDto);
        Task<bool> DeleteDepartmentAsync(int id);
        Task<bool> DepartmentExistsAsync(int id);
    }
}
