using StudentManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Infrastructure.Persistence.Implementation
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartmentByUserID(Guid UserID);
        Task<Department> GetListDepartmennt(string DepartmentName);
        Task<Department> CreateDepartment(Department department);
    }
}
