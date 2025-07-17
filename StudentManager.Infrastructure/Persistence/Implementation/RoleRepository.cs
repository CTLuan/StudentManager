using Microsoft.EntityFrameworkCore;
using StudentManager.Domain.Entities;
using StudentManager.Domain.Interfaces;
using StudentManager.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Infrastructure.Persistence.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DBContext _db;

        public RoleRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<Role> CreateRole(Role Role)
        {
            await _db.Roles.AddAsync(Role);
            return Role;
        }

        public async Task<Role> DeleteRole(Role Role)
        {
            _db.Roles.Remove(Role);
            return Role;
        }

        public async Task<List<Role>> GetRoleById(Guid Id)
        {
            var role = await _db.Users
                        .Where(x => x.UserID == Id)
                        .Include(x => x.UserRoles)
                        .ThenInclude(ur => ur.Role)
                        .SelectMany(u => u.UserRoles)
                        .Select(ur => ur.Role)
                        .ToListAsync();

            return role;
        }

        public async Task<Role> GetRoleByName(string RoleName)
        {
            var role = await _db.Roles.FirstOrDefaultAsync(x => x.RoleName == RoleName);
            return role;
        }

        public async Task<bool> UpdateRole(Role Role)
        {
            var role = _db.Roles.FirstOrDefaultAsync(x => x.RoleID == Role.RoleID);
            if (role != null)
            {
                _db.Roles.Update(Role);
                return true;
            }
            return false;
        }
    }
}
