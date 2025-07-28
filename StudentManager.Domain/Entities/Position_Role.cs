using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Entities
{
    public class Position_Role
    {
        [Key]
        public Guid PositionRoleID { get; set; }
        public Guid PositionID { get; set; }
        public Position? Position { get; set; }
        public Guid RoleID { get; set; }
        public Role? Role { get; set; }
    }
}
