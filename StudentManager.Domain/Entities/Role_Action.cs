using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Entities
{
    public class Role_Action
    {
        [Key]
        public Guid RoleActionID { get; set; }
        public Guid RoleID { get; set; }
        public Guid ActionID { get; set; }
        public Action? Actions { get; set; }
        public Role? Roles { get; set; }
    }
}
