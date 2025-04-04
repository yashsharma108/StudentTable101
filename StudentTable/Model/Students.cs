﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace StudentTable.Model
{
    public class Students
    {
        [Key]
        public int StudentID { get; set; }
        public int StudentNumber { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public DateTime? GraduationDate { get; set; }

        public ICollection<StudentCourses>? StudentCourses { get; set; }
    }
}
