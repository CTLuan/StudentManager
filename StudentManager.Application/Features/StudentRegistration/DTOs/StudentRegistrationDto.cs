using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Features.StudentRegistration.DTOs
{
    public class StudentRegistrationDto
    {
        public Guid StudentRegistration { get; set; }
        public string? StudentName { get; set; }
        public string? ParentName { get; set; }
        public string? ParentPhone { get; set; }
        public string? ParentEmail { get; set; }
        public string? StudentCode { get; set; }
        public string? StudentPhone { get; set; }
    }
}
