
namespace StudentTable.DTO
{
    public class StudentDto
    {
        public int StudentID { get; set; }
        public int StudentNumber { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public DateTime? GraduationDate { get; set; }
    }
}
