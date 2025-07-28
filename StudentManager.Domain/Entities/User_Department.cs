using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Entities
{
    public class User_Department
    {
        [Key]
        public Guid UserDepartmentID { get; set; }
        public Guid UserID { get; set; }
        public User? Users { get; set; }
        public Guid DepartmentID { get; set; }
        public Department? Departments { get; set; }
    }
}
