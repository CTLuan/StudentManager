using StudentManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Infrastructure.Persistence.Services
{
    public class PasswordService : IPassword
    {
        public async Task<string> HashPassword(string Password)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(Password);
            return passwordHash;
        }

        public async Task<bool> VerifyPassword(string PasswordEnter, string PasswordStore)
        {
            var comparePassword = BCrypt.Net.BCrypt.Verify(PasswordEnter, PasswordStore);

            return comparePassword;
        }
    }
}
