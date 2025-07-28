using StudentManager.Domain.Entities;
using StudentManager.Domain.Interfaces;
using StudentManager.Infrastructure.Persistence.Context;
using StudentManager.Shared.Contants;
using StudentManager.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Infrastructure.Persistence.Implementation
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DBContext _db;

        public UserRoleRepository(DBContext db)
        {
            _db = db;
        }

        //public async Task<bool> CreateUserRole(UserRole UserRole)
        //{
        //    try
        //    {
        //        await _db.UserRoles.AddAsync(UserRole);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
            
        //}
    }
}
