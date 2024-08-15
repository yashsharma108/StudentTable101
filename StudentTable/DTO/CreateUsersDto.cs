using System.ComponentModel.DataAnnotations;

namespace StudentTable.DTO
{
    public class CreateUsersDto
    {
        [Required, MaxLength(50)]
        public string UsersName { get; set; }

        [Required, MaxLength(50)]
        public string Password { get; set; }

        [Required, MaxLength(250)]
        public string Email { get; set; }
    }
}

