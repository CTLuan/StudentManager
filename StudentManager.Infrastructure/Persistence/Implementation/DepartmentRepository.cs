using Microsoft.EntityFrameworkCore;
using StudentManager.Domain.Entities;
using StudentManager.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Infrastructure.Persistence.Implementation
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DBContext _db;

        public DepartmentRepository(DBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Task<Department> CreateDepartment(Department department)
        {
            _db.Departments.Add(department);
            return Task.FromResult(department);
        }

        public async Task<List<Department>> GetDepartmentByUserID(Guid UserID)
        {
            var departments = await _db.Users
                .Where(x => x.UserID == UserID)
                .SelectMany(u => u.User_Departments)
                .Select(ud => ud.Departments)
                .ToListAsync();
            return departments;
        }

        public async Task<Department> GetListDepartmennt(string DepartmentName)
        {
            var department = await _db.Departments
                .FirstOrDefaultAsync(d => d.DepartmentName == DepartmentName);

            return department;
        }
    }
}
