using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentTable.Model
{
    public class Departments
    {
        [Key]
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public ICollection<Courses>? Courses { get; set; }
        public ICollection<Instructors>? Instructors { get; set; }
    }
}
