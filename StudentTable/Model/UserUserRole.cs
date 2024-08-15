using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTable.Model
{
    public class UserUserRole
    {
        [Key]
        public int UserUserRoleId { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users? User { get; set; }

        public int UserRoleId { get; set; }
        [ForeignKey("UserRoleId")]
        public UserRoles? UserRole { get; set; }
    }
}