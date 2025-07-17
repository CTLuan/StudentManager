using StudentManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> CreateRole(Role Role);
        Task<bool> UpdateRole(Role Role);
        Task<Role> DeleteRole(Role Role);
        Task<List<Role>> GetRoleById(Guid Id);
        Task<Role> GetRoleByName(string RoleName);
    }
}
