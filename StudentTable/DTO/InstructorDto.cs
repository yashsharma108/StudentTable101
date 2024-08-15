using System;

namespace StudentTable.DTO
{
    public class InstructorDto
    {
        public int InstructorId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Status { get; set; }
        public DateTime? HireDate { get; set; }
        public double? AnnualSalary { get; set; }
        public int DepartmentId { get; set; }
    }
}
