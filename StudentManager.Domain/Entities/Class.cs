using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Entities
{
    public class Class
    {
        [Key]
        public Guid ClassID { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public string ClassCode { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public Guid GradeLevelID { get; set; }
        public GradeLevel? GradeLevel { get; set; }
    }
}
