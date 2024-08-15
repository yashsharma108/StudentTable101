using System.ComponentModel.DataAnnotations;

namespace StudentTable.DTO
{
    public class LoginDto
    {
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required, MaxLength(50)]
        public string Password { get; set; }
    }
}