using StudentManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Features.Users.DTOs
{
    public class UserPermissionDTO
    {
        public Guid UserID { get; set; }
        public List<Department> UserDepartment { get; set; }
        public List<Role> Roles { get; set; }                                      
        public List<StudentManager.Domain.Entities.Action> Action { get; set; }
    }
}
