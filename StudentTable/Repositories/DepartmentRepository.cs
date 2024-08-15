using Microsoft.EntityFrameworkCore;
using StudentTable.Data;
using StudentTable.DTO;
using StudentTable.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTable.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly SchoolDbContext _context;

        public DepartmentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync()
        {
            return await _context.Departments
                .Select(d => new DepartmentDto
                {
                    DepartmentId = d.DepartmentId,
                    DepartmentName = d.DepartmentName
                })
                .ToListAsync();
        }

        public async Task<DepartmentDto> GetDepartmentAsync(int id)
        {
            return await _context.Departments
                .Where(d => d.DepartmentId == id)
                .Select(d => new DepartmentDto
                {
                    DepartmentId = d.DepartmentId,
                    DepartmentName = d.DepartmentName
                })
                .FirstOrDefaultAsync();
        }

        public async Task<DepartmentDto> AddDepartmentAsync(DepartmentDto departmentDto)
        {
            var department = new Departments
            {
                DepartmentName = departmentDto.DepartmentName
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            departmentDto.DepartmentId = department.DepartmentId;

            return departmentDto;
        }

        public async Task<DepartmentDto> UpdateDepartmentAsync(int id, DepartmentDto departmentDto)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return null;
            }

            department.DepartmentName = departmentDto.DepartmentName;

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DepartmentExistsAsync(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return departmentDto;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return false;
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DepartmentExistsAsync(int id)
        {
            return await _context.Departments.AnyAsync(e => e.DepartmentId == id);
        }
    }
}
