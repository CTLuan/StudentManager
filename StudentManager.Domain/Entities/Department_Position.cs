using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Entities
{
    public class Department_Position
    {
        [Key]
        public Guid DepartmentPositionID { get; set; }
        public Guid PositionID { get; set; }
        public Guid DepartmentID { get; set; }
        public Position? Positions { get; set; }
        public Department? Departments { get; set; }
    }
}
