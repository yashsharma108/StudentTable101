using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTable.Model
{
    public class Instructors
    {
        [Key]
        public int InstructorId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Status { get; set; }
        public DateTime? HireDate { get; set; }
        public double? AnnualSalary { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Departments? Departments { get; set; }

        public ICollection<Courses>? Courses { get; set; }
    }
}
