namespace StudentTable.DTO
{
    public class CourseDto
    {
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public int CourseNumber { get; set; }
        public string? CourseDescription { get; set; }
        public int CourseUnits { get; set; }
        public int DepartmentId { get; set; }
        public int InstructorID { get; set; }
    }
}
