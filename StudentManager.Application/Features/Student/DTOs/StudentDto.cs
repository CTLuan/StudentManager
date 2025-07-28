using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Features.Student.DTOs
{
    public class StudentDto
    {
        public Guid StudentID { get; set; }
        public string? StudentName { get; set; }
        public string? StudentCode { get; set; }
        public string? Status { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
