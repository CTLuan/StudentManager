using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Entities
{
    public class Role
    {
        [Key]
        public Guid RoleID { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string RoleCode { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public ICollection<Position_Role>? User_Positions { get; set; }
        public ICollection<Position_Role>? Position_Roles { get; set; }
        public ICollection<Role_Action>? Role_Actions { get; set; }
    }
}
