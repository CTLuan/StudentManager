using StudentManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Interfaces
{
    public interface IChatService
    {
        Task SendMessageAsync(ChatMessages message);
        Task<List<ChatMessages>> GetChatHistoryAsync(string userId1, string userId2);
    }
}
