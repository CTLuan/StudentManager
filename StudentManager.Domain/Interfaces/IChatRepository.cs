using StudentManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Interfaces
{
    public interface IChatRepository
    {
        Task AddMessageAsync(ChatMessages message);
        Task<List<ChatMessages>> GetMessagesBetweenAsync(Guid user1Id, Guid user2Id);
    }
}
