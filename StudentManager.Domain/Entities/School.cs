using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Entities
{
    public class School
    {
        [Key]
        public Guid SchoolID { get; set; }
        public string SchoolName { get; set; } = string.Empty;
        public string SchoolCode { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public ICollection<GradeLevel> GradeLevels { get; set; }
    }
}
