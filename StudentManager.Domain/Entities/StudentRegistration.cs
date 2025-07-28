using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Entities
{
    public class StudentRegistration
    {
        [Key]
        public Guid StudentRegistrationID { get; set; }
        public string? StudentName { get; set; }
        public string? StudentCode { get; set; }
        public string? ParentName { get; set; }
        public string? ParentEmail { get; set; }
        public string? ParentPhone { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string? RegistrationSource { get; set; }
        public bool HasStarted { get; set; } = false;
        public bool Active { get; set; } = true;
    }
}
