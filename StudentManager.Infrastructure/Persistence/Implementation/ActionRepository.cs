using Microsoft.EntityFrameworkCore;
using StudentManager.Domain.Interfaces;
using StudentManager.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Infrastructure.Persistence.Implementation
{
    public class ActionRepository : IActionRepository
    {
        private readonly DBContext _db;

        public ActionRepository(DBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }


        public Task<Domain.Entities.Action> CreateAction(Domain.Entities.Action action)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Action> DeleteAction(Domain.Entities.Action action)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.Action>> GetActionById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Action> GetActionByName(string ActionName)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.Action>> GetActions()
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.Action>> GetActionsByRoleID(Guid RoleID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Domain.Entities.Action>> GetActionsByUserID(Guid UserID)
        {
            var actions = await _db.User_Departments
                .Where(ud => ud.UserID == UserID)
                .SelectMany(ud => ud.Departments.Department_Positions)
                .SelectMany(dp => dp.Positions.Position_Roles)
                .SelectMany(pr => pr.Role.Role_Actions)
                .Select(ra => ra.Actions)
                .ToListAsync();

            return actions;
        }

        public Task<bool> UpdateAction(Domain.Entities.Action action)
        {
            throw new NotImplementedException();
        }
    }
}
