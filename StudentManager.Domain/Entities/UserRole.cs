using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Entities
{
    public class UserRole
    {
        [Key]
        public Guid UserID { get; set; }
        public User User { get; set; } = new User();
        public Guid RoleID { get; set; }
        public Role Role { get; set; } = new Role();
    }
}
