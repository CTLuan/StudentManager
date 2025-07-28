using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Entities
{
    public class GradeLevel
    {
        [Key]
        public Guid GradeLevelID { get; set; }
        public string GradeLevelName { get; set; } = string.Empty;
        public string GradeLevelCode { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public Guid SchoolID { get; set; }
        public School? School { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}
