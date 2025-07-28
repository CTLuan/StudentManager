using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Entities
{
    public class Position
    {
        [Key]
        public Guid PositionID { get; set; }
        public string PositionName { get; set; } = string.Empty;
        public string PositionCode { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public ICollection<Department_Position>? Department_Positions { get; set; }
        public ICollection<Position_Role>? Position_Roles { get; set; }
    }
}
