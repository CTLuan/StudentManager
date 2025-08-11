using Microsoft.AspNetCore.SignalR;
using StudentManager.Application.Interfaces;
using StudentManager.Domain.Entities;
using StudentManager.Domain.Interfaces;
using StudentManager.Infrastructure.Persistence.Context;
using StudentManager.Infrastructure.Persistence.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Infrastructure.Persistence.Services
{
    public class ChatService : IChatService
    {
        public Task<List<ChatMessages>> GetChatHistoryAsync(string userId1, string userId2)
        {
            throw new NotImplementedException();
        }

        public Task SendMessageAsync(ChatMessages message)
        {
            throw new NotImplementedException();
        }
    }
}
