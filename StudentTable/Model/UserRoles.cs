using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTable.Model
{
    public class UserRoles
    {
        [Key]
        public int UserRoleID { get; set; }
        public string UserRoleName { get; set; } = string.Empty;
       
    }
}