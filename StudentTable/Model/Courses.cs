using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTable.Model
{
    public class Courses
    {
        [Key]
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public int CourseNumber { get; set; }
        public string? CourseDescription { get; set; }
        public int CourseUnits { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Departments? Departments { get; set; }

        public int InstructorID { get; set; }
        [ForeignKey("InstructorID")]
        public Instructors? Instructor { get; set; }

        public ICollection<StudentCourses>? StudentCourses { get; set; }
    }
}
