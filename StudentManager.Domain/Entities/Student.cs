using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Entities
{
    public class Student
    {
        [Key]
        public Guid StudentID { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreateOn { get; set; }
        public Guid CreateBy { get; set; }
        public bool Active { get; set; }
    }
}
