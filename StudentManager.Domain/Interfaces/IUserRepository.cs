using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManager.Domain.Entities;

namespace StudentManager.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByID(Guid UserID);
        Task<bool> CreateUser(User Request);
    }
}
