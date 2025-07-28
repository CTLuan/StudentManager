using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Entities
{
    public class Department
    {
        [Key]
        public Guid DepartmentID { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string DepartmentCode { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public ICollection<User_Department>? User_Departments { get; set; }
        public ICollection<Department_Position>? Department_Positions { get; set; }
    }
}
