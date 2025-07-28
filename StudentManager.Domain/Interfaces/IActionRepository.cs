using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Interfaces
{
    public interface IActionRepository
    {
        Task<Entities.Action> CreateAction(Entities.Action action);
        Task<bool> UpdateAction(Entities.Action action);
        Task<Entities.Action> DeleteAction(Entities.Action action);
        Task<List<Entities.Action>> GetActionById(Guid Id);
        Task<Entities.Action> GetActionByName(string ActionName);
        Task<List<Entities.Action>> GetActions();
        Task<List<Entities.Action>> GetActionsByRoleID(Guid RoleID);
        Task<List<Entities.Action>> GetActionsByUserID(Guid UserID);

    }
}
