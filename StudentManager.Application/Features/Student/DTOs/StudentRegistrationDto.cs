using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Features.Student.DTOs
{
    public class StudentRegistrationDto
    {
        public Guid StudentRegistrationID { get; set; }
        public string? StudentName { get; set; }
        public string? StudentCode { get; set; }
        public string? ParentName { get; set; }
        public string? ParentPhone { get; set; }
        public string? ParentEmail { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string? RegistrationSource { get; set; }
        public bool HasStarted { get; set; }
    }
}
