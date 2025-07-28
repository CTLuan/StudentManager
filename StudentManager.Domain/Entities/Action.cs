using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Entities
{
    public class Action
    {
        [Key]
        public Guid ActionID { get; set; }
        public string ActionName { get; set; } = string.Empty;
        public string ActionCode { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public ICollection<Role_Action>? Role_Actions { get; set; }
    }
}
