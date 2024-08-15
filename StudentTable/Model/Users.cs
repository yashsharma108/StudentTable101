using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTable.Model
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string? Username { get; set; }

        [Required, MaxLength(50)]
        public string? Password { get; set; }

        [Required, MaxLength(250)]
        public string? Email { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
      
    }
}