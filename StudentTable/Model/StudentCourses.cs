using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTable.Model
{
    public class StudentCourses

    {
        [Key]
        public int StudentCourseId { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Students? Student { get; set; }

    
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]

        public Courses? Courses { get; set; }
    }
}
