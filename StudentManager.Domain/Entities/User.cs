using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime CreateOn { get; set; } = DateTime.Now;
        public bool Active { get; set; } = true;
        public ICollection<User_Department>? User_Departments { get; set; }
    }
}
