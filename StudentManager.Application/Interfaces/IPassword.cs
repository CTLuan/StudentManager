using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Interfaces
{
    public interface IPassword
    {
        Task<string> HashPassword(string Password);
        Task<bool> VerifyPassword(string PasswordEnter, string PasswordStore);
    } 
}
